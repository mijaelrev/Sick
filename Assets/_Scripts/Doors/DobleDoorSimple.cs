using System.Collections.Generic;
using UnityEngine;

public class DobleDoorSimple : MonoBehaviour, IInteractable
{
    private GameObject _Player;

    [Header("Puertas")]
    [SerializeField] GameObject _doorA, _doorB;

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
    void Update()
    {
        Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = true;
            Debug.Log("canOpen es " + canOpen);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
                OpenDoor(_doorA, _doorB, DefaultRotation, RotateToAngle, RotateToAngleInvert, timeBetwentAction);
            }
            else if (open == true)
            {
                OpenDoor(_doorA, _doorB, DefaultRotation, DefaultRotation, DefaultRotation,  timeBetwentAction);
            }
            open = !open;
            Debug.Log("el estado de la puerta es " + open);
        }
    }

    public void OpenDoor(GameObject _DoorA, GameObject _DoorB, Quaternion defaultAngle, Quaternion rotateToAngle, Quaternion rotateNegativeAngle, float TimeBewentSlerp)
    {
        _DoorA.transform.localRotation = defaultAngle;
        _DoorA.transform.localRotation = rotateToAngle;
        Quaternion.Slerp(defaultAngle, rotateToAngle, TimeBewentSlerp);
        _DoorB.transform.localRotation = defaultAngle;
        _DoorB.transform.localRotation = rotateNegativeAngle;
        Quaternion.Slerp(defaultAngle, rotateNegativeAngle, TimeBewentSlerp);
    }
    
}
