using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillaHexagonal : MonoBehaviour
{
	[Header("Dimensiones")]
	[Tooltip("Cantidad de celdas de la grilla (columnas)")]
	public int columns = 6;
	[Tooltip("Cantidad de celdas de la grilla (filas)")]
	public int rows = 6;

	public static Color[] selectableColors =
	{
		Color.white, Color.red, Color.yellow, Color.blue
	};
	public static Color[] transitionColors =
	{
        Color.white,
        new Color(1, 1, 1),       // black
		new Color(0.5f, 0, 1), // violet
		new Color(1, 0.5f, 0), // orange
		new Color(0, 1f, 0), // green
	};

	private Cell[] cells;

	void Awake()
	{
		cells = new Cell[rows * columns];
		CreateGrid();
	}

    private void Start()
    {
		foreach (var cell in cells)
		{
			cell.hexMesh.Triangulate();
			cell.transform.localPosition = new Vector3(0, 0, 0);
		}
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

    private void CreateCell(int x, int z, int i)
    {
        Vector3 position = GetCellPosition(x, z);

        cells[i] = Cell.CreateCell();
        cells[i].transform.SetParent(transform, false);
        cells[i].name += " " + i;
        cells[i].transform.localPosition = position;

        cells[i].coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        cells[i].SetMaterial();

        SetNeighbours(x, z, i);
    }

    private void SetNeighbours(int x, int z, int i)
    {
        if (x > 0)
        {
            cells[i].SetNeighbor(HexDirection.W, cells[i - 1]);
        }
        if (z > 0)
        {
            if ((z & 1) == 0)
            {
                cells[i].SetNeighbor(HexDirection.SE, cells[i - columns]);
                if (x > 0)
                {
                    cells[i].SetNeighbor(HexDirection.SW, cells[i - columns - 1]);
                }
            }
            else
            {
                cells[i].SetNeighbor(HexDirection.SW, cells[i - columns]);
                if (x < columns - 1)
                {
                    cells[i].SetNeighbor(HexDirection.SE, cells[i - columns + 1]);
                }
            }
        }
    }

    private static Vector3 GetCellPosition(int x, int z)
    {
        Vector3 position;
        position.x = (x + z * 0.5f // Each row is offset along the X axis by the inner radius.
                     - z / 2) // Re-align cell offset into rectangular grid
                     * (HexMetrics.innerRadius * 2f); // the distance between adjacent hexagon cells in the X direction is equal to twice the inner radius.
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f); // the distance to the next row of cells should be 1.5 times the outer radius.
        return position;
    }
}
