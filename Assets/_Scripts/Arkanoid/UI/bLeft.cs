using UnityEngine;
using System.Collections;

public class bLeft : MonoBehaviour {

    private Paddle paddle;

    void Start () {
        paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
    }

    public void moveLeft()
    {
        paddle.axis = -1f;
    }

    public void stopLeft()
    {
        paddle.axis = 0;
    }

}
