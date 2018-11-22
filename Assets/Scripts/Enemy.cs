using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool walk;

    public AudioClip enemyHitAudioClip;
    public AudioSource soundSource;


    private Animator animator;
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("Walk", walk ? 1 : 0);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enemy OnTriggerEnter " + other.tag);
        
        if (other.tag == "Wall")
        {
            // Debug.Log("Enemy Rotate");
            int d = Mathf.CeilToInt(Random.Range(0.1f, 3)); // random 1,2,3
            transform.Rotate(0, 90 * d, 0);
        }
        if (other.tag == "Bullet")
        {
            //Debug.Log("hit by bullet play sound");
            soundSource.PlayOneShot(enemyHitAudioClip);

        }

    }


}
