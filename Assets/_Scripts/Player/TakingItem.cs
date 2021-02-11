using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingItem : MonoBehaviour
{
    public GameObject coger;

    public enum Type { Weapon, harmless, anyObject };//aqui pon los tipos de objetos que abran
    public Type itemType;
}
