using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed = 1f;
    public float axis = 0;


    private Vector3 playerPos = new Vector3(0, -15f, 0);

    void Update()
    {
        float xPos = transform.position.x + (axis * paddleSpeed);
        // xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, 2f, 34f), -15f, 0f);
        transform.position = playerPos;

    }
}