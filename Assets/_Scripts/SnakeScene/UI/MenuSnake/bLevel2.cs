using UnityEngine;
using System.Collections;

public class bLevel2 : MonoBehaviour {

    private MenuSnake mSnake;

    void Start()
    {
        mSnake = GameObject.Find("GM").GetComponent<MenuSnake>();
    }

    public void toLevel2()
    {
        mSnake.showLevel(2);
    }
}
