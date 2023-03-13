using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellColor
{
    white, red, yellow, blue
}
public enum TransitionColor
{
    black, violet, orange, green
}

public enum HexDirection
{
    NE, E, SE, SW, W, NW
}


public class Cell : MonoBehaviour
{
    public Material Material;
    public HexCoordinates coordinates;
    private int colorIndex = 0;
    private Material currentMaterial;

    [SerializeField] Cell[] neighbors = new Cell[6];

    [SerializeField] CellColor cellColor;

    public MeshHexagonal hexMesh;
    private MeshRenderer meshRenderer;

    public static Cell CreateCell()
    {
        GameObject obj = new GameObject();
        Cell cell = obj.AddComponent<Cell>();
        cell.hexMesh = obj.AddComponent<MeshHexagonal>();
        cell.meshRenderer = obj.AddComponent<MeshRenderer>();

        return cell;
    }

    public Cell GetNeighbor(HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    public void SetMaterial()
    {
        meshRenderer.material = Material;
    }

    public void ChangeColor()
    {
        meshRenderer.material.color = GetNextColor();
    }

    private Color GetNextColor()
    {
        switch (cellColor)
        {
            case CellColor.white:
                cellColor = CellColor.red;
                return Color.red;
            case CellColor.red:
                cellColor = CellColor.yellow;
                return Color.yellow;
            case CellColor.yellow:
                cellColor = CellColor.blue;
                return Color.blue;
            case CellColor.blue:
                cellColor = CellColor.white;
                return Color.white;
            default:
                Debug.Log("Default case");
                return Color.white;
        }
    }

    private void TransitionColor()
    {

    }
}
    