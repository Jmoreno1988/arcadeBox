using UnityEngine;
using System.Collections;

public class SnakeBody : MonoBehaviour {

    private Renderer rend;
    public int[] initPosGrid;
    private int[] lastPosGrid;
    private int[] actualPosGrid;

    void Start () {
        rend = GetComponent<Renderer>();
        initPosGrid = new int[] { 100, 100 };
        lastPosGrid = initPosGrid;
        actualPosGrid = initPosGrid;
    }
	
	void Update () {
        
	}

    public void moveTo(int x, int y)
    {
        var cell = GameObject.Find("c(" + x + "," + y + ")");
        var posX = cell.transform.position.x;
        var posY = cell.transform.position.y + 0.5F;
        var posZ = cell.transform.position.z;

        rend.transform.position = new Vector3(posX, posY, posZ);

        actualPosGrid = new int[] { x, y };
    }

    public int[] getLastPosGrid()
    {
        return lastPosGrid;
    }

    public void setLastPosGrid(int[]pos)
    {
        lastPosGrid = pos;
    }

    public void setActualPosGrid(int[]pos)
    {
        actualPosGrid = pos;
    }

    public int[] getActualPosGrid()
    {
        return actualPosGrid;
    }
}
