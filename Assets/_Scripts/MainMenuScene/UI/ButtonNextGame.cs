﻿using UnityEngine;
using System.Collections;

public class ButtonNextGame : MonoBehaviour {

    private ControllerMainMenu ctrl;

    // Use this for initialization
    void Start () {
        ctrl = GameObject.Find("ControllerMainMenu").GetComponent<ControllerMainMenu>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showNextGame()
    {
        ctrl.showNextGame("right");
    }
}