using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private AudioSource audio;

    private float speed = -0.2f;   //キューブの移動速度
    private float deadLine = -10;  //消滅位置
    
    
    
    // Use this for initialization
	void Start () {

        this.audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(this.speed, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
        
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            this.audio.Play();
        }
        
    }
}
