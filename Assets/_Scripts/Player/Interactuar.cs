using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    [SerializeField] Inventario inventario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Object")
        {
           inventario.ToTakeAdd(coll.gameObject);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Object")
        {
            inventario.ToTakeRemove(coll.gameObject);
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject.tag == "Sail")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                coll.gameObject.GetComponent<CambiarScene>().OpenMenu();
            }
        }

        if(coll.transform.gameObject.tag == "Puerta")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //coll.transform.parent.parent.GetComponent<Puerta>().Abrir(coll.gameObject);
            }
        }
    }
}
