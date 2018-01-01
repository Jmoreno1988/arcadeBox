using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScore : MonoBehaviour {

    public static int score;
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score;
	}
}
