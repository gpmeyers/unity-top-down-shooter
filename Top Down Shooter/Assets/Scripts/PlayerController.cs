using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Field containing Player Movement Speed 
    public float movementSpeed;

    // Field containing a reference to the player Rigidbody
    private Rigidbody myRigidbody;

    // Input Data for player movement
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    // Reference to camera for player look controls
    private Camera mainCamera;

    public GunController gun;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // For player movement controls
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * movementSpeed;

        // For player look controls
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        // For player combat controls
        if (Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }

        // For TransLoc
        if(Input.GetMouseButtonDown(1) && !gun.transLocFired)
        {
            gun.transLocFired = true;
            gun.FireTranslocator();
        }
    }

    // FixedUpdate is used for physics
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
