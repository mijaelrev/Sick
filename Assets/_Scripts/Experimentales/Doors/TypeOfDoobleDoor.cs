using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfDoobleDoor : MonoBehaviour
{
    public GameObject _Player;
    Animator _animator;

    private const string OPEN_DOOR = "OpenDoor";
    private bool openTheDoor = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(OPEN_DOOR, openTheDoor);
    }

    private void OnTriggerStay(Collider other)
    {
        openTheDoor = !openTheDoor;
        if (other.CompareTag("Player") && Input.GetButtonDown("Action"))
        {
            _animator.SetBool(OPEN_DOOR, openTheDoor = true);
        }
        else if(other.CompareTag("Player") && Input.GetButtonDown("Action") && openTheDoor == true)
        {
            _animator.SetBool(OPEN_DOOR, openTheDoor = false);
        }
    }

}
