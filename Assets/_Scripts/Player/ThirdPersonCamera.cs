using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform Target;
    public Transform TheCamera;
    public float sensibilityX = 2f, sensibilityY = 2f;

    [SerializeField]float distance = 3.5f;

    private Camera _Camera;
    private float mouseX, mouseY;
    private const float maxRotation = 80f, minRotation = -80;

    void Start()
    {
        TheCamera = transform;
        _Camera = Camera.main;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * sensibilityX;
        mouseY= Mathf.Clamp(mouseY, minRotation, maxRotation);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        TheCamera.position = Target.position + rotation * direction;
        TheCamera.LookAt(Target.position);
    }
}
