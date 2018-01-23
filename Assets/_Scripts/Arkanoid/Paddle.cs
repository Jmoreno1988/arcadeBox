using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    public float axis = 0;
    private Ball ball;
    
    private Vector3 playerPos = new Vector3(0, -15f, 0);

    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
    }

    void Update()
    {
        float xPos = transform.position.x + (axis * paddleSpeed);

        if (Input.GetAxis("Horizontal") != 0)
            xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);

        playerPos = new Vector3(Mathf.Clamp(xPos, 2f, 34f), -15f, 0f);
        transform.position = playerPos;
    }

    public void collisionBall(string posPaddle)
    {
        float z = 15;
        Rigidbody rb  = ball.getRigidBody();
        Quaternion rotation = Quaternion.Euler(0, 0, z); ;
        
        if (posPaddle == "left") z = 15;
        if (posPaddle == "right") z = -15;
        
        rb.velocity = rotation * rb.velocity;
    }
}