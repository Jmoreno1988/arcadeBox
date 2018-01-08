using UnityEngine;
using System.Collections;

public class ButtonRight : MonoBehaviour {

    private MasterBehaviour mb;
    
	void Start () {
	    mb = GameObject.Find("Master").GetComponent<MasterBehaviour>();
    }
	
	void Update () {
	
	}

    public void preshButton()
    {
        mb.turnSnake("right");
    }
}
