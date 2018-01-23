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

        ballInitialVelocity = 800f;
        ballMaxVelocity = 1400f;
        ballVelocity = ballInitialVelocity;
}

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
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
        transform.position = new Vector3(paddle.transform.position.x, -13.5f, 0);
    }

    public void  Destroy()
    {
        Destroy(gameObject);
    }

    public void speedUp(float vel)
    {
        if ((ballVelocity + vel) < ballMaxVelocity)
            ballVelocity += vel;
        else
            ballVelocity = ballMaxVelocity;
    }

    public void speedDown(float vel)
    {
        if ((ballVelocity - vel) < ballInitialVelocity)
            ballVelocity -= vel;
        else
            ballVelocity = ballInitialVelocity;
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }
}