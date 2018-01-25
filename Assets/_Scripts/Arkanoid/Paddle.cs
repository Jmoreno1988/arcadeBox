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

    public void collisionBall(int posPaddle)
    {
        float z = 0;
        Rigidbody rb  = ball.getRigidBody();

        if (posPaddle == 1) z = 0;
        if (posPaddle == 2) z = -11.25f;
        if (posPaddle == 3) z = -22.5f;
        if (posPaddle == 4) z = -33.75f;
        if (posPaddle == 5) z = -45f;
        if (posPaddle == 6) z = -56.25f;
        if (posPaddle == 7) z = -67.5f;
        if (posPaddle == 8) z = -78.75f;
        if (posPaddle == 9) z = -90;

        Quaternion rotation = Quaternion.Euler(0, 0, z);
        
        // La ponemos en un angulo de -45º
        rb.velocity = new Vector3(- 1* ball.getSpeed(), 1 * ball.getSpeed(), 0);
        rb.velocity = rotation * rb.velocity;
    }
}

// Angulos rebote
// ==============
//  1  -45    - 0
//  2  -33.75 - 11.25
//  3  -22.5  - 22.5
//  4  -11.25 - 33.75
//  5   0     - 45
//  6   11.25 - 56.25
//  7   22.5  - 67.5
//  8   33.75 - 78.75
//  9   45    - 90



