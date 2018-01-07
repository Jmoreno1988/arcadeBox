using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextReady : MonoBehaviour {

    public static string readyText;
    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        readyText = "";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = readyText;
    }
}
