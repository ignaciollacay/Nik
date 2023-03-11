using System;
using UnityEngine;

public class Star : CelestialBody
{
    public Star()
    {
        bodyName = "New Star";
        size = 10;
        orbit = 0;
        type = Types.Star;
    }
}
