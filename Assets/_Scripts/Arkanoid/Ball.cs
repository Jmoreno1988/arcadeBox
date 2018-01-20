using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 1600f;

    private GM GM;
    private Rigidbody rb;
    private bool ballInPlay;
    private Paddle paddle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GM = GameObject.Find("GM").GetComponent<GM>();
        paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
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
}