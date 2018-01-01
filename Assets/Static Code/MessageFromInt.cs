using UnityEngine;
using System.Collections.Generic;

public static class MessageFromInt
{
    public static int FoodCount = 0;
    public static List<FoodBehaviour> foods = new List<FoodBehaviour>();
    public static bool WinCondition()
    {
        return FoodCount > 1;
    }
}
