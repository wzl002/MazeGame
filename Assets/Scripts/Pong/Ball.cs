using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    public static float speed = 0.3f; // 0.3;

    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ballWaitToStart());
        // start with random angle of the ball: 0 is top middle, 180 is button
        double degree = Random.Range(30, 120);
        degree *= Random.Range(-1, 1) > 0 ? 1 : -1; // random left or right
        direction = AngleDirection(degree);
        
    }

    IEnumerator ballWaitToStart() // ball start to move after appear 1 second, not immidiatelly
    {
        yield return new WaitForSeconds(1);
    }

    // transform from angle degree to direction
    protected Vector3 AngleDirection(double degree)
    {
        double angle = System.Math.PI * degree / 180.0;
        float x = (float)System.Math.Sin(angle);
        float z = (float)System.Math.Cos(angle);
        return new Vector3(x * speed, 0, z * speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * speed, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            //Debug.Log("OnTriggerEnter" + direction.x);

            direction.z = -direction.z;
        }
        else if (other.tag == "Racket")
        {
            // direction.x = -direction.x;
            double degree = Random.Range(30, 120);
            degree *= -direction.x > 0 ? 1 : -1; // from left to right or opposite
            direction = AngleDirection(degree);
        }
        else if (other.tag == "Border")
        {
            //Debug.Log("position: " + transform.position.x);

            GameManager.instance.AddPoint(transform.position.x > 0); // if x >0, hit right border, left win

            Destroy(gameObject);
        }

    }

}
