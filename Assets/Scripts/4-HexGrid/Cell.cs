using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum HexDirection
{
    NE, E, SE, SW, W, NW
}

public static class HexDirectionExtensions
{
    public static HexDirection Opposite(this HexDirection direction)
    {
        if ((int)direction < 3)
            return direction + 3;
        else
            return direction - 3;
    }

    public static HexDirection Previous(this HexDirection direction)
    {
        if (direction == HexDirection.NE)
            return HexDirection.NW;
        else
            return direction - 1;
    }

    public static HexDirection Next(this HexDirection direction)
    {
        if (direction == HexDirection.NW)
            return HexDirection.NE;
        else
            return direction + 1;
    }
}


public class Cell : MonoBehaviour
{
    public Material Material;
    public HexCoordinates coordinates;
    private int colorIndex = 0;

    [SerializeField] private Cell[] neighbors = new Cell[6];
    [SerializeField] private int[] neighborColors = new int[6];

    public MeshHexagonal hexMesh;
    private MeshRenderer meshRenderer;


    public static Cell CreateCell()
    {
        GameObject obj = new GameObject();
        obj.name = "Hex Cell";
        Cell cell = obj.AddComponent<Cell>();
        cell.hexMesh = obj.AddComponent<MeshHexagonal>();
        cell.meshRenderer = obj.AddComponent<MeshRenderer>();

        return cell;
    }

    public void SetMaterial()
    {
        meshRenderer.material = Material;
    }

    public Cell GetNeighbor(HexDirection direction)
    {
        return neighbors[(int)direction];
    }
    public void SetNeighbor(HexDirection direction, Cell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }

    public void SetNextColor()
    {
        meshRenderer.material.color = GetNextColor();
        UpdateNeighbours();
    }

    private void UpdateNeighbours()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            Cell neighbor = neighbors[i];

            if (neighbor == null)
                continue;

            if (neighbor.colorIndex == 0)
            {
                // Check neighboring cells
                for (int j = 0; j < neighbor.neighbors.Length; j++)
                {
                    Cell nextNeighbor = neighbor.neighbors[j];
                    if (nextNeighbor == null)
                        continue;

                    if (OtherColor(nextNeighbor))
                    {
                        neighbor.meshRenderer.material.color = GetTransitionColor(colorIndex, nextNeighbor.colorIndex);
                    }
                }
            }
            // search other neighbors to see if there are 3 primary colors with same transition cell
        }
    }
    private bool OtherColor(Cell other)
    {
        if (other.colorIndex != 0 && other.colorIndex != colorIndex)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Color GetNextColor()
    {
        if (colorIndex < GrillaHexagonal.selectableColors.Length - 1)
            colorIndex++;
        else
            colorIndex = 0;

        return GrillaHexagonal.selectableColors[colorIndex];
    }

    private Color GetTransitionColor(int i1, int i2)
    {
        Color color1 = GrillaHexagonal.selectableColors[i1];
        Color color2 = GrillaHexagonal.selectableColors[i2];

        if ((color1 == Color.red && color2 == Color.blue) ||
           (color1 == Color.blue && color2 == Color.red))
            return GrillaHexagonal.transitionColors[2]; // violet

        if ((color1 == Color.red && color2 == Color.yellow) ||
           (color1 == Color.yellow && color2 == Color.red))
            return GrillaHexagonal.transitionColors[3]; // orange

        if ((color1 == Color.yellow && color2 == Color.blue) ||
           (color1 == Color.blue && color2 == Color.yellow))
            return GrillaHexagonal.transitionColors[4]; // green

        else
        {
            return GrillaHexagonal.transitionColors[0];
        }
    }
    private Color GetTransitionColor(int i1, int i2, int i3)
    {
        Color color1 = GrillaHexagonal.selectableColors[i1];
        Color color2 = GrillaHexagonal.selectableColors[i2];
        Color color3 = GrillaHexagonal.selectableColors[i3];

        if (color1 != color2 && color2 != color3)
        {
            return GrillaHexagonal.transitionColors[1];
        }
        else
            return GrillaHexagonal.transitionColors[0];
    }

    private void SetTransitionColor()
    {

    }
}
    