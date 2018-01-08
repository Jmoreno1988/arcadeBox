using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour {

    private CanvasGroup menuPause;

    // Use this for initialization
    void Start () {
        menuPause = GetComponent<CanvasGroup>();

        //hide();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hide()
    {
        menuPause.alpha = 0;
        menuPause.interactable = false;
        menuPause.blocksRaycasts = false;
    }

    public void show()
    {
        menuPause.alpha = 1;
        menuPause.interactable = true;
        menuPause.blocksRaycasts = true;
    }

    
}
