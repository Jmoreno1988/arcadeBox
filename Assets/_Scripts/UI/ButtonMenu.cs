using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonMenu : MonoBehaviour {

    private MasterBehaviour mb;
    
    void Start()
    {
        mb = GameObject.Find("Master").GetComponent<MasterBehaviour>();
    }

    void Update () {
	
	}

    public void preshButton() {
        mb.pauseGame();
    }
}
