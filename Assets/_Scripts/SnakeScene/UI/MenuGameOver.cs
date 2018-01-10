using UnityEngine;
using System.Collections;

public class MenuGameOver : MonoBehaviour {

    private CanvasGroup menuGameOver;

    void Start()
    {
        menuGameOver = GetComponent<CanvasGroup>();
    }

    public void hide()
    {
        menuGameOver.alpha = 0;
        menuGameOver.interactable = false;
        menuGameOver.blocksRaycasts = false;
    }

    public void show()
    {
        menuGameOver.alpha = 1;
        menuGameOver.interactable = true;
        menuGameOver.blocksRaycasts = true;
    }
}
