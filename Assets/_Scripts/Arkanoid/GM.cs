using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    private int lives;
    private ArrayList levels;
    private int actualLevel;
    private int score;
    private Ball ball;
    private ArrayList listPowerUps;
    private PowerUp powerUp;

    public int posDead;


    public float resetDelay = 1f;
    public GameObject gameOver;
    public GameObject youWon;

    void Awake()
    {
        levels = new ArrayList();
        levels.Add(new Level("level1", 78, new string[] {"velx2", "vel-2"}));
        levels.Add(new Level("level2", 111, new string[] { }));
        levels.Add(new Level("level3", 111, new string[] { }));

        lives = 3;
        actualLevel = 0;
        score = 0;
        posDead = -22;
        listPowerUps = new ArrayList();

        tScore.score = score;

        ball = GameObject.Find("Ball").GetComponent<Ball>();

        generatePowerUps((Level)levels[0]);
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
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loseLife()
    {
        lives--;
        tLives.lives = lives;
        ball.reset();
        CheckGameOver();
    }

    public void DestroyBrick(Transform t)
    {
        var level = ((Level)levels[actualLevel]);
        level.totalBricks--;
        score += 100;
        tScore.score = score;

        //Comprobamos si suleta powerUp
        for (int i = 0; i < listPowerUps.Count; i++)
            if ((int)listPowerUps[i] == level.totalBricks)
                generatePowerup(level.powerUps[i], t);

        CheckGameOver();
    }

    private void generatePowerup(string name, Transform tBrick)
    {
        GameObject pU = (GameObject)Instantiate(Resources.Load("powerUps/" + name));
        pU.transform.position = tBrick.position;
    }

    // Cargar pantalla
    // ===============
    // Para pasar de pantalla 
    // Se destruye el ultimo bloque
    // Se cae una de las paredes laterales, luego la otra y finalmente el techo


    // POWER UPS
    // =========
    // Son aleatorios
    // Se sueltan cuando falten un nuemro x de bloques por romper.
    // Se asignan tantos numeros como powerups
    // Al romper un bloque se comprueba si toca soltar powerup
    // Si toca se instancia en el lugar del bloque
    // El powerup sera una pildora con gravedad que caera perpendicular a la pala
    // Si la tabla lo toca se aplica el power up


    // TODO
    // ====
    // Velocidad de la pelota
    // Velocidad de la pelota aumentar por rebote

    private void generatePowerUps(Level level)
    {
        /*
        var pUps = level.powerUps;
        var totalBricks = level.totalBricks;

        for (int i = 0; i < pUps.Length; i++)
        {
            var contains = true;
            do
            {
                int rand = (int)Helper.GetRandomNumber(0, totalBricks);

                if (!listPowerUps.Contains(rand))
                {
                    listPowerUps.Add(rand);
                    contains = false;
                }

            } while (contains);
        }
        */
        /*
        for (int i = 0; i < level.powerUps.Length; i++)
            listPowerUps.Add(i);
            */

        listPowerUps.Add(76);
        listPowerUps.Add(77);
    }
}