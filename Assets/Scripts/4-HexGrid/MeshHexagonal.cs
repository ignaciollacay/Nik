using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class MeshHexagonal : MonoBehaviour
{
	private Mesh mesh;
	private MeshCollider meshCollider;

	private List<Vector3> vertices = new List<Vector3>();
	private List<int> triangles = new List<int>();

	List<Color> colors;

	// TODO: Constructor?
	void Awake()
	{
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		meshCollider = gameObject.AddComponent<MeshCollider>();
		mesh.name = "Hex Mesh";
	}

	public void Triangulate()
	{
		Vector3 center = transform.position;
		for (int i = 0; i < 6; i++)
		{
			AddTriangle(
				center,
				center + HexMetrics.corners[i],
				center + HexMetrics.corners[i + 1]
			);
		}

		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.RecalculateNormals();
		meshCollider.sharedMesh = mesh;
	}

	private void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
	{
		int vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
	}
}