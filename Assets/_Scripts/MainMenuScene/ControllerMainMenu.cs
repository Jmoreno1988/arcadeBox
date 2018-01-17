using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControllerMainMenu : MonoBehaviour {
    
    private Camera cam;
    private int actualDir;
    private Vector3[] positions;
    private string[] names;

    void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        actualDir = 0;
        positions = new Vector3[] { new Vector3(0, 75, -65), new Vector3(100, 75, -65) };
        names = new string[] { "Snake", "Arkanoid" };

        cam.setPosition(positions[actualDir]);
        TextButtonPlay.game = names[actualDir];
    }
	
	void Update () {
	
	}

    public void showNextGame(string dir)
    {
        switch (dir)
        {
            case "right":
                actualDir++;

                if (actualDir >= positions.Length)
                    actualDir = 0;

                cam.setPosition(positions[actualDir]);
                TextButtonPlay.game = names[actualDir];

                break;

            case "left":

                break;
        }
    }

    public void playGame()
    {
        switch(names[actualDir])
        {
            case "Snake":
                SceneManager.LoadScene("MenuSnake", LoadSceneMode.Single);
                break;

            case "Arkanoid":
                SceneManager.LoadScene("arkanoid1", LoadSceneMode.Single);
                break;

        }
    }
}
