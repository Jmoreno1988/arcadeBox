using UnityEngine;
using System.Collections;

public class MenuReady : MonoBehaviour {

    private CanvasGroup menu;

    // Use this for initialization
    void Start()
    {
        menu = GetComponent<CanvasGroup>();
        hide();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hide()
    {
        menu.alpha = 0;
        menu.interactable = false;
        menu.blocksRaycasts = false;
    }

    public void show()
    {
        menu.alpha = 1;
        menu.interactable = true;
        menu.blocksRaycasts = true;
    }
}
