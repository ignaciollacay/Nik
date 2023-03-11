using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class PlayerInputs : NetworkBehaviour
{
    [SerializeField] private float sensibility = 300;
    [SerializeField] private float movementSpeed = 0.1f;

    private float xRotation, yRotation;



    /*// Ocultar cursor
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }*/

    // Transform is synced to server via ClientNetWorkTransform component in player. Could use a network variable if needed
    private void Update()
    {
        if (!IsOwner) return; // Only update current player
        CameraMovement();
        CameraRotation();
    }

    private void CameraMovement()
    {
        // Actualizar posicion solo cuando se presionan las teclas wasd
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            // Movement input
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            // Player Movement
            transform.position += transform.forward * moveY * movementSpeed + transform.right * moveX * movementSpeed;
        }
    }
    private void CameraRotation()
    {
        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
        {
            // Player input
            float lookX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensibility;
            float lookY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensibility;
            yRotation += lookX;
            xRotation -= lookY;

            // Player Rotation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
    }
}
/*
public class PlayerInputs : NetworkBehaviour
{
    [SerializeField] private float sensibility = 300;
    [SerializeField] private float movementSpeed = 0.1f;

    private float xRotation, yRotation;

    // Network Variables to andle server sync
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    public NetworkVariable<Quaternion> Rotation = new NetworkVariable<Quaternion>();

    // Ocultar cursor
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Transform is synced to server via ClientNetWorkTransform component in player. Could use a network variable if needed
    private void Update()
    {
        if (IsOwner) // Only update current client
        {
            Move();
        }
    }

    public void Move()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("is Server");
            // Update player position, then network
            if (MovementInput())
            {
                var newPos = GetCameraMovement();
                transform.position = newPos;
                Position.Value = newPos;
            }
            if (RotationInput())
            {
                var newRot = GetCameraRotation();
                transform.rotation = newRot;
                Rotation.Value = newRot;
            }
        }
        else
        {
            Debug.Log("Not Server");
            // Update network, which will update the player.
            if (MovementInput())
            {
                SubmitPositionRequestServerRpc();
            }
            if (RotationInput())
            {
                SubmitRotationRequestServerRpc();
            }
        }
    }
    [ServerRpc]
    private void SubmitRotationRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Rotation.Value = GetCameraRotation();
    }
    [ServerRpc]
    private void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Position.Value = GetCameraMovement();
    }

    private Vector3 GetCameraMovement()
    {
        var position = transform.position;

        // Movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Update Player Position
        position += transform.forward * moveY * movementSpeed + transform.right * moveX * movementSpeed;

        return position;
    }
    private Quaternion GetCameraRotation()
    {
        var rotation = transform.rotation;

        // Player input
        float lookX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensibility;
        float lookY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensibility;
        yRotation += lookX;
        xRotation -= lookY;

        // Player Rotation
        rotation = Quaternion.Euler(xRotation, yRotation, 0);

        return rotation;
    }
    private bool MovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool RotationInput()
    {
        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
*/