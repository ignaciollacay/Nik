using UnityEngine;

public class Moon : CelestialBody
{
    public Moon()
    {
        bodyName = "New Moon";
        size = 1;
        orbit = 5;
        type = Types.Moon;
    }
}
