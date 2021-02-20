using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfEnterHere : MonoBehaviour
{
    public GameObject _Player;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player" && Input.GetButtonDown("Action"))
        {

        }
        
    }

}
