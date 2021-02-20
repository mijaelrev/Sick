using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MANUAL
 * Este script esta diseñador solo para las puertas 5
 
*/
public enum TypeOfDoor {simpleDoor, dobleDoor, elevatorDoor}
public class DoorController : MonoBehaviour
{
    public TypeOfDoor typeOfDoor;

    TypeOfSimpleDoor IsSimpleDoor; //aqui estan los scripts de los tipos de puertas 
    TypeOfDoobleDoor IsDoobleDoor; //Con este Script sera mas rapido añadir otro tipo de puerta en el futuro
    TypeOfElevatorDoor IsElevatorDoor;


    Animator _animator;
    private const string OPEN_DOOR = "OpenDoor";
    private bool openTheDoor = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(OPEN_DOOR, openTheDoor);
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Action"))
        {
            openTheDoor = !openTheDoor;
            _animator.SetBool(OPEN_DOOR, openTheDoor);
        }

    }

    void SetTypeOfDoor(TypeOfDoor NewTypeTheDoor)
    {
        if (NewTypeTheDoor == TypeOfDoor.simpleDoor)
        {

        }
        else if (NewTypeTheDoor == TypeOfDoor.dobleDoor)
        {

        }
        else if (NewTypeTheDoor == TypeOfDoor.elevatorDoor)
        {

        }
        this.typeOfDoor = NewTypeTheDoor;

    }

    void SimpleDoor()
    {
        SetTypeOfDoor(TypeOfDoor.simpleDoor);
    }
    void DoobleDoor()
    {
        SetTypeOfDoor(TypeOfDoor.dobleDoor);
    }
    void ElevatorDoor()
    {
        SetTypeOfDoor(TypeOfDoor.elevatorDoor);
    }

}
