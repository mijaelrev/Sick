using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleDoorSpecial : MonoBehaviour, IInteractable
{
    private GameObject _Player;

    [Header("Puertas")]
    [SerializeField] GameObject _doorA, _doorB;

    [Header("configuracion de valores")]
    [SerializeField, Range(0, 1)] float distanceBetwentDoors = 0.0177f;
    [SerializeField, Range(-5, 5)] float basicPositionX = 0.0096f;
    [SerializeField] float timeBetwentAction = 0.1f;
    [SerializeField] bool KeyDoor;

    private Vector3 DefaultPositionA;
    private Vector3 NewPosition;
    private Vector3 NewPositionInvert;
    private Vector3 DefaultPositionB;

    [HideInInspector] private bool open;
    public bool canOpen = false;
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");

        DefaultPositionA = new Vector3(-basicPositionX, 0,0);
        DefaultPositionB = new Vector3(basicPositionX, 0,0);
        NewPosition = new Vector3(-distanceBetwentDoors,0,0);
        NewPositionInvert = new Vector3(distanceBetwentDoors,0,0);

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
                OpenDoor(_doorA, _doorB, DefaultPositionA, DefaultPositionB, NewPosition, NewPositionInvert, timeBetwentAction);
            }
            else if (open == true)
            {
                OpenDoor(_doorA, _doorB, DefaultPositionA, DefaultPositionB,DefaultPositionA, DefaultPositionB, timeBetwentAction);
            }
            open = !open;
            Debug.Log("el estado de la puerta es " + open);

        }
    }

    public void OpenDoor(GameObject _DoorA, GameObject _DoorB, Vector3 defaultPositionA, Vector3 defaultPositionB, Vector3 movePositionTo, Vector3 movePositionNegativeTo, float moveDistance)
    {
        _DoorA.transform.localPosition = defaultPositionA;
        _DoorA.transform.localPosition = movePositionTo;
        Vector3.Slerp(defaultPositionA, movePositionTo, moveDistance);
        _DoorB.transform.localPosition = defaultPositionB;
        _DoorB.transform.localPosition = movePositionNegativeTo;
        Vector3.Slerp(defaultPositionA, movePositionNegativeTo, moveDistance);

    }
}
