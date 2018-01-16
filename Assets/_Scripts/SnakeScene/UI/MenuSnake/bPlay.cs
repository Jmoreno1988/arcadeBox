using UnityEngine;
using System.Collections;

public class bPlay : MonoBehaviour {

    private MenuSnake mSnake;

    void Start()
    {
        mSnake = GameObject.Find("GM").GetComponent<MenuSnake>();
    }

    public void loadLevel()
    {
        mSnake.loadLevel();
    }
}
