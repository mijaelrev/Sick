using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] GameObject inventBar;//barra de inventario
    GameObject[] inventSpace;
    LinkedList<GameObject> toTake = new LinkedList<GameObject>();

    [SerializeField] Transform hand;

    int selecion = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventSpace = new GameObject[inventBar.GetComponentInChildren<Transform>().childCount];

        for (int i = 0; i < inventSpace.Length; i++)
        {
            inventSpace[i] = inventBar.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cambiar();

        TakeObjects();
    }

    void TakeObjects()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (toTake.Count > 0)
            {
                if (toTake.First.Value.GetComponent<TakingItem>().itemType == TakingItem.Type.Weapon)
                {
                    for (int i = 0; i < inventSpace.Length; i++)
                    {
                        if (inventSpace[i].GetComponent<Espacio>().tipo == Espacio.type.libre)
                        {
                            inventSpace[i].GetComponent<Espacio>().item = Coger(toTake.First.Value.GetComponent<TakingItem>().coger);
                            inventSpace[i].GetComponent<Espacio>().item.transform.SetParent(hand);
                            inventSpace[i].GetComponent<Espacio>().item.transform.position = hand.transform.position;

                            Destroy(toTake.First.Value);
                            toTake.RemoveFirst();
                            break;
                        }
                        else if (inventSpace[selecion].GetComponent<Espacio>().item != null && selecion != 0)
                        {
                            Soltar(inventSpace[selecion].GetComponent<Espacio>().item.GetComponent<Item>().soltar, 
                                inventSpace[selecion].GetComponent<Espacio>().item);

                            inventSpace[selecion].GetComponent<Espacio>().item = Coger(toTake.First.Value.GetComponent<TakingItem>().coger);
                            inventSpace[selecion].GetComponent<Espacio>().item.transform.SetParent(hand);
                            inventSpace[selecion].GetComponent<Espacio>().item.transform.position = hand.transform.position;

                            Destroy(toTake.First.Value);
                            toTake.RemoveFirst();
                            break;
                        }
                    }
                }
            }
            
        }
    }

    GameObject Coger(GameObject index)
    {
        return Instantiate(index, transform.position + new Vector3(0, 2, 0), transform.rotation);
    }
    GameObject Soltar(GameObject index, GameObject index2)
    {
        GameObject objeto = Instantiate(index, transform.position + new Vector3(0, 2, 0), transform.rotation);
        Destroy(index2);
        return objeto;
    }

    void cambiar()
    {
        for (int i = 0; i < inventSpace.Length; i++)
        {
            if(i == selecion) inventSpace[i].GetComponent<Espacio>().seleccion = true;
            if(i != selecion) inventSpace[i].GetComponent<Espacio>().seleccion = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selecion = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selecion = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selecion = 2;
        }
    }

    public void ToTakeAdd(GameObject objeto) => toTake.AddLast(objeto);

    public void ToTakeRemove(GameObject objeto) => toTake.Remove(objeto);
}
