using UnityEngine;
using System.Collections;

public class ButtonMenuPauseMainMenu : MonoBehaviour {

    private MasterBehaviour mb;
    
    void Start()
    {
        mb = GameObject.Find("Master").GetComponent<MasterBehaviour>();
    }

    public void goToMainMenu()
    {
        mb.goToMainMenu();
    }
}
