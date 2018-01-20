using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
    private GM GM;
    public GameObject brickParticle;

    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GM>();
    }

    void OnCollisionEnter(Collision other)
    {
        //Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.DestroyBrick(transform);
        Destroy(gameObject);
    }
}