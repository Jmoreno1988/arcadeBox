using UnityEngine;
using System.Collections;

public class bLevel3 : MonoBehaviour {

    private MenuSnake mSnake;

    void Start()
    {
        mSnake = GameObject.Find("GM").GetComponent<MenuSnake>();
    }

    public void toLevel3()
    {
        mSnake.showLevel(3);
    }
}
