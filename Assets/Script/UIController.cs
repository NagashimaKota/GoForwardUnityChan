﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private GameObject gameOverText;    //ゲームオーバーテキスト
    private GameObject runLengthText;   //走行距離テキスト
    private float len = 0;              //走った距離
    private float speed = 0.03f;        //走る速度
    private bool isGameOver = false;    //ゲームオーバーの判定

    
    // Use this for initialization
	void Start () {

        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");

	}
	
	// Update is called once per frame
	void Update () {
		
        if(this.isGameOver == false)
        {
            //走った距離を更新する
            this.len += this.speed;
            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }
        
        //ゲームオーバーになった時
        if (this.isGameOver)
        {
            //クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込み
                SceneManager.LoadScene("GameScene");
            }
        }
	}

    
    public void GameOver()
    {
        //ゲームオーバーになったとき、画面上にゲームオーバーを表示
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
