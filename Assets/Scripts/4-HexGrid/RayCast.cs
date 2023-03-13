using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Raycast();
    }

    // TODO: Event with RayCastHit parameter
    // a) subscription from cell -> change color
    // b) subscription from grid -> get Vector3 position -> convert to coordinates -> Get Cell -> change color
    private void Raycast()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (raycastHit.collider.TryGetComponent(out Cell cell))
            {
                cell.SetNextColor();
            }
        }
    }
}