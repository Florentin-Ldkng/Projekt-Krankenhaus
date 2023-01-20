using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    private CharacterController controller = null;
    private SoundManager sManager = null;

    private float moveSmoothTime = .1f;
    private float mouseSmoothTime = .03f;
    private float mouseSensitivity = 2f;
    private float cameraPitch = 0.0f;
    private float walkSpeed = 4f;
    private float gravity = -13f;
    private float velocityY = 0.0f;
    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;
    private Vector2 currentMouseDelta = Vector2.zero;
    private Vector2 ccurrentMouseDeltaVelocity = Vector2.zero;
    private Vector2 targetDir = Vector2.zero;
    private RaycastHit hit;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        sManager = GetComponent<SoundManager>();
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        UpdateInteractions();
        sManager.PlayStepSound(targetDir);
    }


    private void UpdateMouseLook()
    {
        Vector2 targetmouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetmouseDelta, ref ccurrentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
    private void UpdateMovement()
    {
        targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
        {
            velocityY = 0;
        }
        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }
    private void UpdateInteractions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCamera.transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Panel":
                        hit.collider.GetComponent<EPScript>().UseElectroPanel();
                        break;
                    case "Door":
                        hit.collider.GetComponent<DoorScript>().OpenDoor();
                        break;
                }
            }
        }

    }
}
