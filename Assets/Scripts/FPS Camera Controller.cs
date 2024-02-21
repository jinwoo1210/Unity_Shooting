using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] float mouseSensitivity;


    private Vector2 inputDir;
    private float yRotation;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        yRotation -= inputDir.y * mouseSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);

        transform.Rotate(Vector3.up, inputDir.x * mouseSensitivity * Time.deltaTime);
        cameraRoot.localRotation = Quaternion. Euler(yRotation, 0, 0);
        //cameraRoot.Rotate(Vector3.right, -inputDir.y * mouseSensitivity * Time.deltaTime);
    }

    private void OnLook(InputValue value)
    {
        inputDir = (value.Get<Vector2>());
    }
}
