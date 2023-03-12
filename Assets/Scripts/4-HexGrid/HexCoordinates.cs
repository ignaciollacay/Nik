using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    public int X => x;
    public int Z => z;
    public int Y => -X - Z;

    [SerializeField]
    private int x, z;

    public HexCoordinates(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    // Display cell coordinates on Inspector
    public override string ToString()
    {
        return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    /// <summary>
    /// Converts from World Coordinate to Hex Coordinate.
    /// </summary>
    /// <param name="position">World Position Coordinates</param>
    /// <returns>Hex Coordinates</returns>
    public static HexCoordinates FromPosition(Vector3 position)
    {
        // Convert coordinates (world to hex)
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;

        // Manage the hex grid offset that makes grid rectangular
        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        // Convert to int since coordinates are round numbers
        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x - y);

        // Manage non-zero results.
        if (iX + iY + iZ != 0)
        {
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(-x - y - iZ);

            if (dX > dY && dX > dZ)
            {
                iX = -iY - iZ;
            }
            else if (dZ > dY)
            {
                iZ = -iX - iY;
            }
        }

        return new HexCoordinates(iX, iZ);
    }
}