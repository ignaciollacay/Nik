using UnityEngine;

public enum Types
{
    Star,
    Planet,
    Moon
}

public abstract class CelestialBody
{
    public string bodyName;
    public int size;
    public Vector3 location;

    public CelestialBody center;
    public int orbit;

    public Types type;
   
    public void CreateBody(Transform solarSystem)
    {
        SetPositionInOrbit();

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(solarSystem);
        sphere.transform.position = location;
        sphere.transform.localScale = sphere.transform.localScale * size;
        sphere.name = bodyName;
    }

    public void SetPositionInOrbit()
    {
        if (type != Types.Star)
        {
            location = center.location;
            var newPos = Random.insideUnitCircle.normalized * orbit;
            location.x += newPos.x;
            location.z += newPos.y;
        }
    }
}
