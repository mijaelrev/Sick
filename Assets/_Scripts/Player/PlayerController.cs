using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;

    CharacterController character;
    [SerializeField] float speed = 5f;

    Camera camara;
    Vector3 camForward;
    Vector3 camRight;

    [SerializeField] float gravityForce;
    float fallVelocity;

    Vector3 direction;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        playerCreated = true;
        camara = Camera.main;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);

        camDirection();

        direction = move.x * camRight + move.z * camForward;

        Gravity();

        direction.y += fallVelocity;

        character.Move(direction * Time.deltaTime * speed);
    }

    void camDirection()
    {
        camForward = camara.transform.forward;
        camRight = camara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void Gravity()
    {
        if (character.isGrounded != true) fallVelocity -= gravityForce * Time.deltaTime;
        if (character.isGrounded) fallVelocity = 0;
    }
}