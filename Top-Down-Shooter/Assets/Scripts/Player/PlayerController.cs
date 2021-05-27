using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera cam;

    public GunController theGun;

    public bool useController;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;


        //Rotate with mouse
        if (!useController)
        {
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

                transform.LookAt(pointToLook);
            }
            if (Input.GetMouseButtonDown(0))
                theGun.isFiring = true;
            if (Input.GetMouseButtonUp(0))
                theGun.isFiring = false;
        }

        //Rotate with controller
        if (useController)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
                theGun.isFiring = true;

            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
                theGun.isFiring = false;
        }
    }

        void FixedUpdate()
        {
            rb.velocity = moveVelocity;
        }
    }
