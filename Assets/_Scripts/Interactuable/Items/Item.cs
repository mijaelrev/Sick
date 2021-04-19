using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Atack()
    {

    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<Inventari>().AddInFloor(this);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<Inventari>().RemoveInFloor(this);
        }
    }
}
