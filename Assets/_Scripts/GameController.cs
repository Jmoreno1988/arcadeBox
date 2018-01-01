using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject foodPrefab;
    public bool Condition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Condition)
            InstantiateFood();
	}

    private void InstantiateFood()
    {
        var obj = GameObject.Instantiate(foodPrefab) as GameObject;
        var script = obj.GetComponent<FoodBehaviour>();
        
    }
}
