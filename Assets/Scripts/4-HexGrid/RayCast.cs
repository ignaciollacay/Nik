using UnityEngine;

public class RayCast : MonoBehaviour
{
    //[SerializeField] private Transform raycastDebugVisual;
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

    private void Raycast()
    {
        Debug.Log("Player Clicked");
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //raycastDebugVisual.position = raycastHit.point;

            if (raycastHit.collider.TryGetComponent(out Cell cell))
            {
                cell.ChangeColor();
                Debug.Log("Player Clicked Cell");
            }
        }
    }
}