using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject inventBar;//barra de inventario
    [SerializeField] GameObject[] inventSpace;
    [SerializeField] List<GameObject> toTake;

    [SerializeField] Transform hand;

    int selecion = 0;

    int freeSpace = 1;//espacio libre mas cercano al cero

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
                if (toTake[0].GetComponent<TakingItem>().itemType == TakingItem.Type.Weapon)
                {
                    for (int i = 0; i < inventSpace.Length; i++)
                    {
                        if (inventSpace[i].GetComponent<Espacio>().tipo == Espacio.type.libre)
                        {
                            inventSpace[i].GetComponent<Espacio>().item = Coger(toTake[0].GetComponent<TakingItem>().coger);
                            inventSpace[i].GetComponent<Espacio>().item.transform.SetParent(hand);
                            inventSpace[i].GetComponent<Espacio>().item.transform.position = hand.transform.position;

                            Destroy(toTake[0]);
                            toTake.RemoveAt(0);
                            break;
                        }
                        else if (inventSpace[selecion].GetComponent<Espacio>().item != null && selecion != 0)
                        {
                            Soltar(inventSpace[selecion].GetComponent<Espacio>().item.GetComponent<Item>().soltar, 
                                inventSpace[selecion].GetComponent<Espacio>().item);

                            inventSpace[selecion].GetComponent<Espacio>().item = Coger(toTake[0].GetComponent<TakingItem>().coger);
                            inventSpace[selecion].GetComponent<Espacio>().item.transform.SetParent(hand);
                            inventSpace[selecion].GetComponent<Espacio>().item.transform.position = hand.transform.position;

                            Destroy(toTake[0]);
                            toTake.RemoveAt(0);
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

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Object")
        {
            toTake.Add(coll.gameObject);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Object")
        {
            toTake.Remove(coll.gameObject);
        }
    }
}
