using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerController : MonoBehaviour
{
    private Vector3 moveVelocity = new Vector3(5.0f, 0.0f, 0.0f);

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 16)
        {
            Destroy(gameObject);
        }
    }

    // FixedUpdate is used for physics
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
