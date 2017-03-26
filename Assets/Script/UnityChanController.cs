using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    Animator animator;
    Rigidbody2D rigid2d;

    private float groundLevel = -3.0f;   //地面の位置
    private float dump = 0.8f;           //ジャンプの速度の減衰
    float jumpVelocity = 20;             //ジャンプの速度
    private float deadLine = -9;         //ゲームオーバーになる位置

    // Use this for initialization
	void Start () {

        this.animator = GetComponent<Animator>();
        this.rigid2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        //走るアニメーションを再生するため、条件を設定
        this.animator.SetFloat("Horizontal", 1);

        //着地しているか調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときはボリュームを０にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;


        //着地した状態でクリックした
        if(Input.GetMouseButton(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2d.velocity = new Vector2(0, this.jumpVelocity);
        }


        //クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if(this.rigid2d.velocity.y > 0)
            {
                this.rigid2d.velocity *= this.dump;
            }
        }

        if(transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }

	}
}
