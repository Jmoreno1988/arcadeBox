using UnityEngine;
using System.Collections;

public class bLevel1 : MonoBehaviour {

    private MenuSnake mSnake;

    void Start () {
	    mSnake = GameObject.Find("GM").GetComponent<MenuSnake>();
    }

    public void toLevel1()
    {
        mSnake.showLevel(1);
    }
}
