using System;
using UnityEngine;
using System.Collections;

public static class Helper {

    public static double GetRandomNumber(double minimum, double maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}
