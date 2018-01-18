using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    private GM GM;

    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GM>();
    }


    void OnTriggerEnter(Collider col)
    {
        GM.LoseLife();
    }
}