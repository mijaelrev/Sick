using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarScene : MonoBehaviour
{
    public enum Scenes {SampleScene, Pruebas_Sleider};//pon aqui los nombre de las scene
    [SerializeField] Scenes[] toSail;
    [SerializeField] GameObject menu;
    List<GameObject> Buttons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        if (toSail.Length > 1)
        {
            if (menu.activeSelf == false)
            {
                menu.SetActive(true);

                for (int i = 0; i < menu.transform.GetChild(0).childCount; i++)
                {
                    Buttons.Add(menu.transform.GetChild(0).GetChild(i).gameObject);
                }

                for (int i = 0; i < toSail.Length; i++)
                {
                    Buttons[i].SetActive(true);
                    Viajar viajar = new Viajar($"{toSail[i]}");
                    Buttons[i].GetComponent<Button>().onClick.AddListener(viajar.Ir);
                }
            }
            else
            {
                menu.SetActive(false);
            }
        }
        else if (toSail.Length == 1) SceneManager.LoadScene($"{toSail[0]}");
    }
}

class Viajar
{
    string lugar;

    public Viajar(string index)
    {
        lugar = index;
    }

    public void Ir()
    {
        SceneManager.LoadScene(lugar);
    }
}
