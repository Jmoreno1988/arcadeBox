using UnityEngine;
using System.Collections;

public class Level {

    public string nameLevel;
    public int totalBricks;

	public Level(string nLevel, int tBricks)
    {
        nameLevel = nLevel;
        totalBricks = tBricks;
    }
}
