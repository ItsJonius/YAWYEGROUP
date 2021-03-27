using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{ 
    public void PlayerPickup()
    {
        
        Inventory.main.hasCube = true; // Tells the inventory system that the player has the cube.
        

        // Remember that the player "picked up" the object

        Destroy(gameObject);
    }

}
