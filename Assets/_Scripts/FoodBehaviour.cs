using UnityEngine;
using System.Collections;

public class FoodBehaviour : MonoBehaviour {
    
    private Renderer rend;
    private MasterBehaviour master;
    private int[] posGrid;

    void Start()
    {
        if (!rend) rend = GetComponent<Renderer>();
        master = GameObject.Find("Master").GetComponent<MasterBehaviour>();
    }
	
	void Update () {
	    
	}

    void OnTriggerEnter(Collider collider)
    {
        //if(collider.gameObject.name == "Snake")
        //{
        //}
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    public void moveToCellGrid(int x, int y)
    {
        var cell = GameObject.Find("c(" + x + "," + y + ")");
        if(!rend) rend = GetComponent<Renderer>();

        rend.transform.position = new Vector3(cell.transform.position.x, 0.73F, cell.transform.position.z);
        posGrid = new int[] { x, y };
    }

    public int[] getPosGrid()
    {
        return posGrid;
    }
}
