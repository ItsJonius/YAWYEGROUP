using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] // Tells Unity the script needs a camera component

public class Raycaster : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        // Did the user click this game tick
        if (cam != null && Input.GetButtonDown("Fire1"))
        {
            // Shoot a ray into the scene, from center of camera
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            // Ray hits something in the scene
            RaycastHit hit;

            // Draw the Ray in the editor
            // Debug.DrawRay(ray.origin, ray.direction, Color.black, .5f);

            if (Physics.Raycast(ray, out hit))
            {
                // Raycast hit a collider in the scene

                DoorController door = hit.transform.GetComponentInParent<DoorController>();
                if (door != null) door.PlayerInteract(transform.parent.position);

                ItemPickup pickup = hit.transform.GetComponent<ItemPickup>();
                if (pickup != null) pickup.PlayerPickup();
            }
        }
    }
}
