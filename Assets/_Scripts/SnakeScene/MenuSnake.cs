using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSnake : MonoBehaviour {

    private Camera cam;
    private int actualDir;
    private Vector3[] positions;
    private int lastPostion;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        actualDir = 0;
        lastPostion = 0;
        positions = new Vector3[] { new Vector3(9.7f, 20.5f, -29.9f), new Vector3(109.7f, 20.5f, -29.9f), new Vector3(209.7f, 20.5f, -29.9f) };

        cam.setPosition(positions[actualDir]);
    }

    public void showLevel(int level)
    {
        actualDir = level - 1;
        cam.setPosition(positions[level - 1]);
    }

    public void loadLevel()
    {
        SceneManager.LoadScene("snakeLevel" + (actualDir + 1), LoadSceneMode.Single);
    }
}
