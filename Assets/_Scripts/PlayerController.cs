using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;
    Rigidbody _rigidbody;
    [SerializeField]float speed = 5f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerCreated = true;
    }

    void Update()
    {
        float keyBoard_H = Input.GetAxis("Horizontal") * speed;
        float keyBoard_V = Input.GetAxis("Vertical") * speed;
    }
    void FixedUpdate()
    {
        
    }

}
