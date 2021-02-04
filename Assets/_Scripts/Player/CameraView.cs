using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField]float mouseSensibility = 125f;
    float xRotation = 0f;
    public Transform Player;
    void Start()
    {
        //Player = FindObjectOfType<Transform>();
    }

    void Update()
    {
        float axis_H = Input.GetAxis("Mouse X")* mouseSensibility * Time.deltaTime;
        float axis_v = Input.GetAxis("Mouse Y")* mouseSensibility * Time.deltaTime;

        xRotation -= axis_v;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        Player.Rotate(Vector3.up * axis_H);
    }
}
