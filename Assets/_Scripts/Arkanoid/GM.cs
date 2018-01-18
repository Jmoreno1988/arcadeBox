using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    private int lives = 3;
    private ArrayList levels;
    private int actualLevel;


    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    //public GameObject paddle;
    public GameObject deathParticles;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {
        Setup();

        levels = new ArrayList();
        levels.Add(new Level("level1", 78));
        levels.Add(new Level("level2", 111));
        levels.Add(new Level("level3", 111));

        actualLevel = 0;

    }

    public void Setup()
    {
        //clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        //Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        var level = ((Level)levels[actualLevel]);
        var totalBricks = level.totalBricks;

        if (totalBricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        //clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        var level = ((Level)levels[actualLevel]);
        level.totalBricks--;
        CheckGameOver();
        Debug.Log(level.totalBricks);
        
    }
}