using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{

    public bool isLeft;

    public int speed = 3;

    private string input;

    private readonly float aiMoveDelay = 0.5f;

    private readonly float aiDistance = 6; // distance is length ai move in one delay time

    private float startTime;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private readonly float MOVE_LIMIT = 3.3f;

    // Use this for initialization
    void Start()
    {
        input = isLeft ? "LeftRacket" : "RightRacket";
    }

    // ai move distance per time

    // Update is called once per frame
    void Update()
    {
        if (!this.isLeft && GameManager.singleMode) // AI 
        {
            AI();
        }
        else
        {
            float move = Input.GetAxis(input) * Time.deltaTime * speed;

            transform.Translate(move * Vector3.forward);
        }
    }

    private void AI()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            float aiSpeed = aiDistance / aiMoveDelay;

            if (Time.time - startTime > aiMoveDelay)
            {
                startTime = Time.time;
                endPosition = startPosition = (transform.position);

                bool goUp = ball.transform.position.z > startPosition.z;
                float move = aiDistance * (goUp ? 1 : -1) * Time.deltaTime * aiSpeed;

                endPosition.z += move;
                endPosition.z = Mathf.Max(-MOVE_LIMIT, endPosition.z);
                endPosition.z = Mathf.Min(MOVE_LIMIT, endPosition.z);
                // Debug.Log(startTime + "  ,  " + startPosition + "  ,  " + endPosition);
            }
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * aiSpeed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / aiDistance;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

        }
    }
}
