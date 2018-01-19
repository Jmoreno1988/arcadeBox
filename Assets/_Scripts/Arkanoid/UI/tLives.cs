using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tLives : MonoBehaviour {

    public static int lives;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        lives = 3;
    }

    void Update()
    {
        text.text = "Lives: " + lives;
    }
}
