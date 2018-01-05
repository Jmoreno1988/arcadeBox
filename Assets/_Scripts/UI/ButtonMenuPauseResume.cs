using UnityEngine;
using System.Collections;

public class ButtonMenuPauseResume : MonoBehaviour {

    private MasterBehaviour mb;

    // Use this for initialization
    void Start () {
        mb = GameObject.Find("Master").GetComponent<MasterBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void resumeGame()
    {
        mb.resumeGame();
    }
}
