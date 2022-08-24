using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteracteable
{
    int value = 1;
    public int Interact()
    {
        Destroy(gameObject);
        return value;
    }
}
