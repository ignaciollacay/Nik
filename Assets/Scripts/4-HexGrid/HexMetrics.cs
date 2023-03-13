using UnityEngine;

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