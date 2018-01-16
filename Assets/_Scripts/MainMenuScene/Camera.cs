using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public void setPosition(Vector3 pos)
    {
        transform.position = pos;
    }



    public void Lerp(Vector3 newPos, float time)
    {
        transform.position = Vector3.Lerp(this.transform.position, newPos, time);
    }
}
