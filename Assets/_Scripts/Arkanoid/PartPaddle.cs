﻿using UnityEngine;
using System.Collections;

public class PartPaddle : MonoBehaviour
{

    public int part;

    private Paddle paddle;
    // Use this for initialization
    void Start()
    {
        paddle = GameObject.Find("Paddle").GetComponent<Paddle>();

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            paddle.collisionBall(part);
        }
    }
}
