using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Adding variables.

    public float moveSpeed = 4;
    public float mouseSensitivityX = 20;
    public float mouseSensitivityY = 20;

    private CharacterController pawn;
    private Camera cam;

    float cameraPitch = 0;

    void Start()
    {
        // Lock the mouse to the bounds of the screen.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }
    
    void TurnPlayer()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        transform.Rotate(0, h * mouseSensitivityX, 0);

        //cam.transform.Rotate(v * mouseSensitivityY, 0, 0);

        cameraPitch += v * mouseSensitivityY;

        if (cameraPitch < -80) cameraPitch = -80;
        if (cameraPitch > 80) cameraPitch = 80;

        //cameraPitch = Mathf.Clamp(cameraPitch, -80, 80); Using the engine's CLAMP feature

        cam.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }
    void MovePlayer()
    {
        // Recieve input:

        // A value between -1 and 1
        float v = Input.GetAxis("Vertical"); //W + S / UP + DOWN
        float h = Input.GetAxis("Horizontal"); //A + D / LEFT + RIGHT

        //transform.position += new Vector3(moveSpeed * Time.deltaTime * h, 0, 0);
        //transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * v);

        //transform.position += transform.right * moveSpeed * Time.deltaTime * h;
        //transform.position += transform.forward * moveSpeed * Time.deltaTime * v;

        //transform.position += (transform.right * h + transform.forward * v) * moveSpeed * Time.deltaTime; //best possible way

        Vector3 speed = (transform.right * h + transform.forward * v) * moveSpeed;

        // If using jumping, use Move instead of Simple.
        pawn.SimpleMove(speed); // Simple move adds gravity, and does not use delta time.
    }
}
