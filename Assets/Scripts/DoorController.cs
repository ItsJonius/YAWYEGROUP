using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorArt;
    
    // Angle of door in degrees
    private float doorAngle = 0;

    public float animLength = .5f;
    private float animTimer = 0;
    private bool animIsPlaying = false;

    private bool isClosed = true;

    void Update()
    {
        // Play the animation
        if (animIsPlaying)
        {
            if (!isClosed)
                animTimer += Time.deltaTime; // Play the animation by deltatime
            else
                animTimer -= Time.deltaTime; // Play backwards

            float percent = animTimer / animLength;

            // Clamp the percent based on if the anim is playing or not.
            if (percent < 0 && isClosed)
            {
                percent = 0;
                animIsPlaying = false;
            }
            if (percent > 1 && !isClosed)
            {
                percent = 1;
                animIsPlaying = false;
            }           
            doorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0); // Set angle of doorArt
        }
    }
    public void PlayerInteract(Vector3 position)
    {        
        if (animIsPlaying) return; // Do nothing

        if (!Inventory.main.hasCube) return; // If the player doesn't have the key do nothing.

        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized; // Makes it between 0 and 1

        bool playerOnOtherSide = (Vector3.Dot(disToPlayer, transform.forward) > 0f);

        isClosed = !isClosed; // toggles state

        if (!isClosed) // only set the angle if the door isn't closed
        {
            doorAngle = 90;
            if (playerOnOtherSide) doorAngle = -90;
        }

        // TURNARY OPERATOR EXAMPLE
        // if (!isClosed) doorAngle = (playerOnOtherSide) ? -90 : 90; // True returns -90 false returns 90

        animIsPlaying = true;

        // Set playhead to end or beginning.
        if (isClosed) animTimer = animLength;
        else animTimer = 0;
        
    }
}
