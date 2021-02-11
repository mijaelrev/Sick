using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Espacio : MonoBehaviour
{
    public GameObject item;

    public enum type {libre, ocupado, mano_principal};
    public type tipo;

    public bool seleccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ObjetoGuardado();

        if (item == null && tipo != type.mano_principal) tipo = type.libre;
    }

    void ObjetoGuardado()
    {
        if (item != null)
        {
            GetComponent<Image>().sprite = item.GetComponent<Item>().imageIU;
            tipo = type.ocupado;

            if (seleccion)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }
}
