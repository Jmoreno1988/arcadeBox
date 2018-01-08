using UnityEngine;
using System.Collections;

public class CloudBehaviour : MonoBehaviour {


    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update () {
        if (!MasterBehaviour.isPause && !MasterBehaviour.isFinish)
        {
            transform.Translate(Vector3.right * Time.deltaTime / 3);
        }
    }
}
