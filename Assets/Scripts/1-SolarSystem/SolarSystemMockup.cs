using System.Collections.Generic;
using UnityEngine;


public class SolarSystemMockup : SolarSystem
{
    public SolarSystemMockup()
    {
        // 1) Una estrella
        Star star = new Star();
        celestialBodies.Add(star);

        // 2) Tres planetas
        Planet[] planets = new Planet[3];
        for (int i = 0; i < planets.Length; i++)
        {
            Planet planet = new Planet();
            planet.center = star; // Set the Center of Gravitation to the last planet.
            planet.orbit = planet.orbit * (i + 1); // Increase distance from Center per planet count
            planets[i] = planet;
            celestialBodies.Add(planets[i]);
        }

        // 3) Dos lunas en el ultimo planeta
        Moon[] moons = new Moon[2];
        for (int i = 0; i < moons.Length; i++)
        {
            Moon moon = new Moon();
            moon.center = planets[2]; // Set the Center of Gravitation to the last planet.
            moon.orbit = moon.orbit * (i + 1); // Increase distance from Center per moon count
            moons[i] = moon;
            celestialBodies.Add(moons[i]);
        }
    }


    [ContextMenu("Create Unitary Solar System")]
    private void CreateUnitarySolarSystem()
    {
        for (int i = 0; i < celestialBodies.Count; i++)
        {
            celestialBodies[i].CreateBody(transform);
        }
    }
}
