using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MasterBehaviour : MonoBehaviour {

    public int score;
    public FoodBehaviour Food;
    public SnakeBehaviour Snake;
    public static bool isFinish;
    public static bool isPause;
    public static bool isInitGame;
    public MenuPause menuPause;
    public MenuReady readyGo;
    private float lastTime;

    void Start () {
        isFinish = false;
        isPause = false;
        isInitGame = false;
        score = 0;
        Snake = GameObject.Find("Snake").GetComponent<SnakeBehaviour>();
        menuPause = GameObject.Find("MenuPause").GetComponent<MenuPause>();
        readyGo = GameObject.Find("ReadyGo").GetComponent<MenuReady>();

        generateFood();
        Snake.grow();
        Snake.grow();
    }
	

	void Update () {
        if (Snake.getActualPosGrid()[0] == Food.getPosGrid()[0] && Snake.getActualPosGrid()[1] == Food.getPosGrid()[1])
        {
            score++;
            Food.destroy();
            generateFood();
            Snake.grow();
            TextScore.score = score * 10;
        }

        if(!isInitGame)
        {
            showReadyGoPanel();
        } 

        if(isFinish)
        {
            showResultPanel();
        }

	}

    public void generateFood()
    {
        var isPosGridClear = true;
        var sBody = Snake.getBody();
        var posHead = Snake.getActualPosGrid();
        var randX = Helper.GetRandomNumber(1, 18);
        var randY = Helper.GetRandomNumber(1, 18);

        do
        {
            if (posHead[0] == randX && posHead[1] == randY)
            {
                randX = Helper.GetRandomNumber(1, 18);
                randY = Helper.GetRandomNumber(1, 18);
                isPosGridClear = false;
            }

            foreach (SnakeBody b in sBody)
            {
                var posBody = b.getActualPosGrid();

                if (posBody[0] == randX && posBody[1] == randY)
                {
                    randX = Helper.GetRandomNumber(1, 18);
                    randY = Helper.GetRandomNumber(1, 18);
                    isPosGridClear = false;
                }

            }
        } while (!isPosGridClear);
        
        Food = Instantiate(Food) as FoodBehaviour;
        Food.moveToCellGrid((int)randX, (int)randY);
    }


    // UI METHODS
    public void initGame()
    {
        
    }

    public void resetGame()
    {
        Start();
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void pauseGame() {
        MasterBehaviour.isPause = true;
        menuPause.show();
    }

    public void resumeGame()
    {
        MasterBehaviour.isPause = false;
        menuPause.hide();
    }

    public void turnSnake(string newDirection)
    {
        Snake.newDirection(newDirection);
    }


    // PRIVATE METHODS
    private void showReadyGoPanel()
    {
        lastTime += Time.deltaTime;

        if (lastTime > 1F && lastTime < 1.5F)
        {
            TextReady.readyText = "Ready?";
            readyGo.show();
        }
        else if (lastTime > 1.5F && lastTime < 2F)
        {
            TextReady.readyText = "3";
        }
        else if (lastTime > 2F && lastTime < 2.5F)
        {
            TextReady.readyText = "2";
        }
        else if (lastTime > 2.5F && lastTime < 3F)
        {
            TextReady.readyText = "1";
        }
        else if (lastTime > 3F && lastTime < 3.5F)
        {
            TextReady.readyText = "GO!!!";
        }
        else if (lastTime > 3.5F)
        {
            isInitGame = true;
            readyGo.hide();
        }
    }

    private void showResultPanel()
    {
        
    }
}
