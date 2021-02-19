using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    //A = puertas que se abren de forma normal hacia donde mire el Player 
    //B = Puertas que se abran como la de un ascensor, osea una para un lado y la otra para el otro lado 
    //    C= esta se abre de la misma forma la A(pero estas son puertas dobles)
    // Start is called before the first frame update
    public enum Type{A, B , C};
    [SerializeField] Type tipo;

    [SerializeField] Animator animator;
    [SerializeField] AnimationClip animacion;
    [SerializeField] GameObject ColliderRight, ColliderLeft;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Abrir(GameObject index)
    {
        if (tipo == Type.A || tipo == Type.C)
        {
            if (index.GetInstanceID() == ColliderRight.GetInstanceID())
            {
                //transform.rotation(transform.forward * 4 * Time.deltaTime);//haz que rote
                animator.SetBool("Open", !animator.GetBool("Open"));
            }
            if (index.GetInstanceID() == ColliderLeft.GetInstanceID())
            {
                //transform.Translate(transform.forward * -4 * Time.deltaTime);//haz que rote
                animator.SetBool("Open", !animator.GetBool("Open"));
            }
        }

        if(tipo == Type.B)
        {
            transform.Translate(transform.up * 4 * Time.deltaTime);// haz que rote
        }
    }
}
