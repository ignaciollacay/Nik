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

	// TODO: Replace to private, as array and set colors.
	public Color defaultColor = Color.white;
	public Color touchedColor = Color.red;

	// TODO: Podria ser totalmente creado de manera procedural, sin prefab
	public HexCell cellPrefab;

	private HexCell[] cells;

	HexMesh hexMesh;

	void Awake()
    {
		cells = new HexCell[rows * columns];
        CreateGrid();

		hexMesh = GetComponentInChildren<HexMesh>();
    }

    private void Start()
    {
		hexMesh.Triangulate(cells);
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

		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
		cell.color = defaultColor;
	}


	// FIXME: Provisorio. Mover de script (Touch Cell -> ChangeColor // Raycast.cs // OnCellClicked Event
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			HandleInput();
		}
	}

	void HandleInput()
	{
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit))
		{
			TouchCell(hit.point);
		}
	}

	void TouchCell(Vector3 position)
	{
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position); // convert the touch position to hex coordinates
		Debug.Log("touched at " + coordinates.ToString());

		// FIXME: triangulates the entire mesh, instead of updating only a cell
		int index = coordinates.X + coordinates.Z * rows + coordinates.Z / 2;
		HexCell cell = cells[index];
		cell.color = touchedColor;
		hexMesh.Triangulate(cells);
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
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius),		// Corner 6
		new Vector3(0f, 0f, outerRadius) // Corner 1
	};
}
