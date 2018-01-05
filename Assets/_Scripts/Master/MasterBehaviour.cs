using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MasterBehaviour : MonoBehaviour {

    public int score;
    public FoodBehaviour Food;
    public SnakeBehaviour Snake;
    public static bool isFinish;
    public static bool isPause;
    public MenuPause menuPause;

    void Start () {
        isFinish = false;
        isPause = false;
        score = 0;
        Snake = GameObject.Find("Snake").GetComponent<SnakeBehaviour>();
        menuPause = GameObject.Find("MenuPause").GetComponent<MenuPause>();

        generateFood();
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
	}

    public void generateFood()
    {
        var randX = Helper.GetRandomNumber(1, 18);
        var randY = Helper.GetRandomNumber(1, 18);

        Food = Instantiate(Food) as FoodBehaviour;
        Food.moveToCellGrid((int)randX, (int)randY);
    }



    // UI METHODS
    public void initGame()
    {
        
    }

    public void resetGame()
    {

    }

    public void goToMainMenu()
    {

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
}
