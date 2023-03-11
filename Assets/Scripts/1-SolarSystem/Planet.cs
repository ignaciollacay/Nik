using UnityEngine;

public class Planet : CelestialBody
{
    public Planet()
    {
        bodyName = "New Planet";
        size = 3;
        orbit = 20;
        type = Types.Planet;
    }
}
