using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Object.Destroy(this.gameObject, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {


	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enemy OnTriggerEnter " + other.tag);

        if (other.tag == "Wall")
        {
            Debug.Log("TRIGGER THE WALL ");
            //TODO: play collide sfx
        }
        if (other.tag == "Floor")
        {
            Debug.Log("TRIGGER THE FLOOR ");
            //TODO: play collide sfx
        }
        if (other.tag == "Enemy")
        {
            Debug.Log("TRIGGER THE ENEMY ");
            Scores.AddScore(1);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collider other)
    {
        //Debug.Log("Enemy OnTriggerEnter " + other.tag);

        if (other.tag == "Wall")
        {
            Debug.Log("TRIGGER THE WALL ");
            //TODO: play collide sfx
        }
        if (other.tag == "Floor")
        {
            Debug.Log("TRIGGER THE FLOOR ");
            //TODO: play collide sfx
        }
        if (other.tag == "Enemy")
        {
            Debug.Log("COLLISION THE ENEMY ");
            Scores.AddScore(1);
            Destroy(this.gameObject);
        }
    }


}
