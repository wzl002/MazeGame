using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    public float inputDelta = 0.1F;

    private float nextInput = 0.5F;
    private float lastInputTime = 0.0F;

    public GameObject bulletPrefab;

    private Camera m_Camera;

    public int shootForce = 1000;

    private void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        lastInputTime = lastInputTime + Time.deltaTime;

        if (lastInputTime > nextInput)
        {
            if (Input.GetButtonDown("FireBall")) // detect input key
            {
                nextInput = lastInputTime + inputDelta;

                // the direction angle of camera, in radian for sin and cos.
                float xzRadian = transform.localRotation.eulerAngles.y * Mathf.PI / 180;
                float yRadian = -m_Camera.transform.localRotation.eulerAngles.x * Mathf.PI / 180;
                Vector3 direction = new Vector3(Mathf.Sin(xzRadian), Mathf.Sin(yRadian), Mathf.Cos(xzRadian));

                // create bullet in a little front of the player.
                GameObject bullet = Object.Instantiate(bulletPrefab, transform.position + direction, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(shootForce * direction);

            }
        }
    }
}
