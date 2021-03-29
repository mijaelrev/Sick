using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour, IInteractable
{
    private GameObject _Player;

    [Header("Puertas")]
    [SerializeField] GameObject _doorA;

    [Header("configuracion de valores")]
    [SerializeField, Range(0, 180)] float RotationValue = 90f;
    [SerializeField, Range(0, -180)] float RotationNegativeValue = -90f;

    [SerializeField] float timeBetwentAction = 0.1f;
    [SerializeField] bool KeyDoor;

    private Quaternion DefaultRotation;
    private Quaternion RotateToAngle;
    private Quaternion RotateToAngleInvert;

    [HideInInspector] private bool open;
    public bool canOpen = false;
    

    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        
        DefaultRotation = Quaternion.Euler(0, 0, 0);
        RotateToAngle = Quaternion.Euler(0, 0, RotationValue);
        RotateToAngleInvert = Quaternion.Euler(0, 0, RotationNegativeValue);

    }
    private void Update()
    {
        ActiveDoor();

    }

    private void ActiveDoor()
    {
        Interact();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canOpen = true;
            Debug.Log("canOpen es " + canOpen);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canOpen = false;
            Debug.Log("canOpen es " + canOpen);

        }
    }

    public void Interact()
    {
        if (Input.GetButtonDown("Action") && canOpen == true)
        {
            if (open == false)
            {
                OpenDoor(_doorA, DefaultRotation, RotateToAngle, timeBetwentAction);
                
            }
            else if (open == true)
            {
                OpenDoor(_doorA, DefaultRotation, DefaultRotation, timeBetwentAction);

            }
            open = !open;
            Debug.Log("el estado de la puerta es " + open);

        }
    }

    public void OpenDoor(GameObject _Door, Quaternion defaultAngle, Quaternion rotateToAngle, float TimeBewentSlerp)
    {
        _Door.transform.localRotation = defaultAngle;
        _Door.transform.localRotation = rotateToAngle;
        Quaternion.Slerp(defaultAngle, rotateToAngle, TimeBewentSlerp);

    }
 
}