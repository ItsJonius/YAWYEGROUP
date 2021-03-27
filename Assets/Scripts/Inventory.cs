using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Singleton design pattern
    private static Inventory _main;
    public static Inventory main
    {
        get { return _main; }
        private set { _main = value; }
    }

    public bool hasCube = false;
    public bool hasFork = false;


    private void Start()
    {
        if (_main == null)
        {
            _main = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading a new scene.

        }else
        {
            Destroy(gameObject); // destroy any extra inventory systems.
        }


    }

}
