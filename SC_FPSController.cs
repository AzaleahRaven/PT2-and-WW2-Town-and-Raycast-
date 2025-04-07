using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    public float groundRayDistance = 1.1f;  // Length of the ray to detect the ground
    public float npcRayDistance = 5f;       // Length of the ray to detect NPCs
    public LayerMask groundLayer;           // Layer for ground detection
    public LayerMask npcLayer;              // Layer for NPC detection

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Check if grounded using CharacterController (more reliable than Raycast here)
        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = -1f; // Small downward force to keep grounded
            }
        }
        else
        {
            moveDirection.y = movementDirectionY;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Draw ground ray (optional debugging)
        Debug.DrawRay(transform.position, Vector3.down * groundRayDistance, Color.green);

        // NPC detection using raycast
        Ray npcRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit npcHit;
        if (Physics.Raycast(npcRay, out npcHit, npcRayDistance, npcLayer))
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * npcRayDistance, Color.red);
        }

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

}
