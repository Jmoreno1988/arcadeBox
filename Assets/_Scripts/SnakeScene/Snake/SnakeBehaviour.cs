using UnityEngine;
using System.Collections;

public class SnakeBehaviour : MonoBehaviour {
    
    public SnakeBody BodyPrefab;
    private Renderer rend;
    private GameObject floor;
    private int[] initPosGrid;
    private int[] lastPosGrid;
    private int[] actualPosGrid;
    private float lastTimeMove;
    private int direction;
    private ArrayList body;


    void Start()
    {
        rend = GetComponent<Renderer>();
        floor = GameObject.Find("Floor");
        initPosGrid = new int[] { 10, 16 };
        lastPosGrid = initPosGrid;
        actualPosGrid = initPosGrid;
        lastTimeMove = 0F;
        direction = 1;
        body = new ArrayList();

        moveToCellGrid(initPosGrid[0], initPosGrid[1]);
    }
	
	void Update () {
        if (MasterBehaviour.isInitGame && !MasterBehaviour.isPause && !MasterBehaviour.isFinish)
        {
            if (!isCollider())
                move();
            else
                MasterBehaviour.isFinish = true;
        }
    }

    void moveToCellGrid(int x, int y)
    {
        var cell = GameObject.Find("c(" + x + "," + y + ")");
        var posX = cell.transform.position.x;
        var posY = cell.transform.position.y + 0.5F;
        var posZ = cell.transform.position.z;

        rend.transform.position = new Vector3(posX, posY, posZ);
    }

    public void grow()
    {
        body.Add(Instantiate(BodyPrefab) as SnakeBody);
    }


    private void move()
    {
        int[] newPosGrid = new int[] {0,0};
        lastTimeMove += Time.deltaTime;

        if (lastTimeMove > 0.1F)
        {
            // Head move
            switch (direction)
            {
                case 1: // UP
                    newPosGrid = new int[] { actualPosGrid[0], actualPosGrid[1] - 1 };
                    moveToCellGrid(newPosGrid[0], newPosGrid[1]);
                    break;

                case 2: // RIGHT
                    newPosGrid = new int[] { actualPosGrid[0] + 1, actualPosGrid[1] };
                    moveToCellGrid(newPosGrid[0], newPosGrid[1]);
                    break;

                case 3: // DOWN
                    newPosGrid = new int[] { actualPosGrid[0], actualPosGrid[1] + 1 };
                    moveToCellGrid(newPosGrid[0], newPosGrid[1]);
                    break;

                case 4: // LEFT
                    newPosGrid = new int[] { actualPosGrid[0] - 1, actualPosGrid[1] };
                    moveToCellGrid(newPosGrid[0], newPosGrid[1]);
                    break;
            }
            actualPosGrid = newPosGrid;
            lastTimeMove = 0;

            var auxPosHead = lastPosGrid;

            // Body move
            foreach (SnakeBody b in body)
            {
                var pos = b.getActualPosGrid();
                b.moveTo(auxPosHead[0], auxPosHead[1]);
                auxPosHead = pos;
            }
           

            lastPosGrid = actualPosGrid;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            newDirection("right");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            newDirection("left");
        }
    }

    private bool isCollider()
    {
        // Comprobacion si se choca con un muro
        switch (direction)
        {
            case 1: // UP
                if (actualPosGrid[1] == 0)
                    return true;
                break;

            case 2: // RIGHT
                if (actualPosGrid[0] == 19)
                    return true;
                break;

            case 3: // DOWN
                if (actualPosGrid[1] == 19)
                    return true;
                break;

            case 4: // LEFT
                if (actualPosGrid[0] == 0)
                    return true;
                break;
        }

        // Comprobacion si se choca consigo mismo
        foreach (SnakeBody b in body)
        {
            var posHead = actualPosGrid;
            var posBody = b.getActualPosGrid();

            if(posHead[0] == posBody[0] && posHead[1] == posBody[1])
            {
                return true;
            }
            
        }

        return false;
    }

    public int[] getActualPosGrid()
    {
        return actualPosGrid;
    }

    public void newDirection(string dir)
    {
        switch(dir)
        {
            case "left":
                direction--;
                rend.transform.Rotate(0, -90, 0);

                if (direction < 1)
                    direction = 4;
                break;
            case "right":
                direction++;
                rend.transform.Rotate(0, 90, 0);

                if (direction > 4)
                    direction = 1;
                break;
        }
    }

    public ArrayList getBody()
    {
        return body;
    }
}
