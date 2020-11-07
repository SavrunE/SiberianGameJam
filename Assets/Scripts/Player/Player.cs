using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Inctanse;
    void Awake()
    {
        if (Inctanse == null)
        {
            Inctanse = this;
        }
        else if (Inctanse = this)
        {
            Destroy(gameObject);
        }
    }
}
