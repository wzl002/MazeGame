using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    // 0.3 y position is ground floor to not reproduce sound
    public AudioClip ImpactAudioClip;
    private AudioSource SoundSource;

    // Use this for initialization
    void Start () {
        SoundSource = GetComponent<AudioSource>();
        Object.Destroy(this.gameObject, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {


	}


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("ENEMY TRIGGER HIT");
            Scores.AddScore(1);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BALL COLLISION: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("COLLIDE THE WALL ");
            SoundSource.PlayOneShot(ImpactAudioClip);
        }
        if (collision.gameObject.tag == "Floor")
        {
            //Debug.Log("COLLIDE THE FLOOR ");
            SoundSource.PlayOneShot(ImpactAudioClip);
        }
    }
    


}
