using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var rotationsPerMinute = 0.5F;
        transform.Rotate(0, 6.0F * rotationsPerMinute * Time.deltaTime, 0);
    }
}
