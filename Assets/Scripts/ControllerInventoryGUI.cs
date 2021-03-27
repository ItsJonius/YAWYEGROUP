using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInventoryGUI : MonoBehaviour
{
    public Transform imgCube; 
    void Update()
    {
        imgCube.gameObject.SetActive(Inventory.main.hasCube);
    }
}
