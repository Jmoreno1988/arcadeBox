using UnityEngine;
using System.Collections;

public class ButtonMenuSnakeList : MonoBehaviour {

    private MasterBehaviour mb;
    
    void Start()
    {
        mb = GameObject.Find("Master").GetComponent<MasterBehaviour>();
    }

    public void goToListLevels()
    {
        mb.goToListLevels();
    }
}
