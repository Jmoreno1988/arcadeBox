using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private GM GM;
    private Rigidbody rb;
    private bool ballInPlay;
    private Paddle paddle;
    private float ballInitialVelocity;
    private float ballVelocity;
    private float ballMaxVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GM = GameObject.Find("GM").GetComponent<GM>();
        paddle = GameObject.Find("Paddle").GetComponent<Paddle>();

        ballInitialVelocity = 18;
        ballMaxVelocity = 30;
        ballVelocity = ballInitialVelocity;
}

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            //rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
            rb.velocity = new Vector3(1 * ballInitialVelocity, 1 * ballInitialVelocity, 0);
        }
        
        if(transform.position.y < GM.posDead)
        {
            GM.loseLife();
        }
    }

    public void reset()
    {
        ballInPlay = false;
        rb.isKinematic = true;
        transform.parent = paddle.transform;
        transform.position = new Vector3(paddle.transform.position.x, -12.47f, 0);
        ballVelocity = ballInitialVelocity;
    }

    public void  Destroy()
    {
        Destroy(gameObject);
    }

    public void speedUp(float vel)
    {
        var uVector = Vector3.Normalize(rb.velocity);  // vector unitario

        if ((ballVelocity + vel) < ballMaxVelocity)
            ballVelocity += vel;
        else
            ballVelocity = ballMaxVelocity;
        
        rb.velocity = new Vector3(uVector.x * ballVelocity, uVector.y * ballVelocity, 0);
    }

    public void speedDown(float vel)
    {
        var uVector = Vector3.Normalize(rb.velocity); // vector unitario

        if ((ballVelocity - vel) > ballInitialVelocity)
            ballVelocity -= vel;
        else
            ballVelocity = ballInitialVelocity;

        rb.velocity = new Vector3(uVector.x * ballVelocity, uVector.y * ballVelocity, 0);
        
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }

    public float getSpeed()
    {
        return ballVelocity;
    }
}