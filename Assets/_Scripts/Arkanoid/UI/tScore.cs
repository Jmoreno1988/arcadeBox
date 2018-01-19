using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tScore : MonoBehaviour {

    public static int score;
    private Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }
    
    void Update()
    {
        text.text = "Score: " + score;
    }
}
