using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deje en Rendering Hexagons.

public class HexGrid : MonoBehaviour
{
	[Header("Dimensiones de la grilla")]
	[Tooltip("Cantidad de celdas de la grilla (columnas)")]
	public int columns = 6;
	[Tooltip("Cantidad de celdas de la grilla (filas)")]
	public int rows = 6;

	// TODO: Deberia de ser creado proceduralmente, no por prefab
	public HexCell cellPrefab;

	private HexCell[] cells;

	void Awake()
    {
        cells = new HexCell[rows * columns];

        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int z = 0, i = 0; z < rows; z++)
        {
            for (int x = 0; x < columns; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    // TODO: Replace cellprefab with primitive plane
	// Cell Placement
    void CreateCell(int x, int z, int i)
	{
		Vector3 position;
		position.x = (x + z * 0.5f // Each row is offset along the X axis by the inner radius.
					 - z / 2) // Re-align cell offset into rectangular grid
					 * (HexMetrics.innerRadius * 2f); // the distance between adjacent hexagon cells in the X direction is equal to twice the inner radius.
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f); // the distance to the next row of cells should be 1.5 times the outer radius.

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
	}
}

public static class HexMetrics
{
	public const float outerRadius = 10f; // Hex max size
	public const float innerRadius = outerRadius * 0.866025404f; // Hex min size

	//  Define the hexagon's orientation (the positions of the six corners relative to the cell's center)
	public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius),						// Corner 1: starting orientation setting the corner on top
		new Vector3(innerRadius, 0f, 0.5f * outerRadius),		// Corner 2
		new Vector3(innerRadius, 0f, -0.5f * outerRadius),		// Corner 3
		new Vector3(0f, 0f, -outerRadius),						// Corner 4
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),		// Corner 5
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius)		// Corner 6
	};
}