using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventari : MonoBehaviour
{
    int selected;
    LinkedList<IItem> inFloor;//en el suelo
    [SerializeField] IItem[] items;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        if(inFloor.Count > 0 && Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }

    void Take()
    {

    }

    void Drop()
    {

    }

    public void AddInFloor(IItem item) => inFloor.AddLast(item);//agregar objetos a la lista
    public void RemoveInFloor(IItem item) => inFloor.Remove(item);//remover objetos de la lista
}
