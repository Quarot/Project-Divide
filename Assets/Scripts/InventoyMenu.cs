using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoyMenu : MonoBehaviour
{
    private static InventoyMenu instance;

    public static InventoyMenu Instance
    {
        get
        {
            return instance;
        }
        private set { instance = value; }
    }

    private void Awake()
    {
        instance = this;
    }
}
