using UnityEngine;
using System.Collections;

public class bRight : MonoBehaviour {

    private Paddle paddle;

    void Start()
    {
        paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
    }

    public void moveRight()
    {
        paddle.axis = 1f;
    }

    public void stopRight()
    {
        paddle.axis = 0;
    }
}
