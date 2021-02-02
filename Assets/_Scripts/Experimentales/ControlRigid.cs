using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider))]
public class ControlRigid : MonoBehaviour
{
    //public Camera _camera;
    public Transform TheCamera;

    private Rigidbody _rigidbody;
    [SerializeField,Header("velocidades")] float speed;
    [SerializeField]float turnSpeed, turnTime = 0.1f;

    Quaternion NewRotation = Quaternion.identity;

    private float horizontal, vertical;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        PlayerMoveDirection();
        
    }

    /// <summary>
    /// entradas del Player
    /// </summary>
    void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Funcion que hace que el Player se mueve entre X y Z donde la camara mire
    /// </summary>
    void PlayerMoveDirection()
    {
        PlayerInput();
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + TheCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            _rigidbody.AddForce(moveDirection * speed * Time.fixedDeltaTime);

        }
    }
}
