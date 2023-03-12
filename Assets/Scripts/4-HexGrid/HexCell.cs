using UnityEngine;


public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Color color;

    // TODO: Refactor hex grid & cell scripts
    // Could integrate HexGrid.CreateCell(), maybe take position as parameter.
    
    //public HexCell()
    //{
    //    // create empty GO
    //    GameObject cell = new GameObject();

    //    // add hex mesh & Triangulate
    //    var hexMesh = cell.AddComponent<HexMesh>();

    //    // add mesh filter & set mesh to Hex Mesh
    //    var meshFilter = cell.AddComponent<MeshFilter>();

    //    // add mesh renderer & set material & set color
    //    var meshRenderer = cell.AddComponent<MeshRenderer>();

    //    // add collider (remove from HexMesh.cs)
    //    cell.AddComponent<MeshCollider>();
    //}
}
