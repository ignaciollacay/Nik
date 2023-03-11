using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SolarSystem : MonoBehaviour
{
    public string solarSystemName;
    public Vector3 location;
    public List<CelestialBody> celestialBodies = new List<CelestialBody>();
}