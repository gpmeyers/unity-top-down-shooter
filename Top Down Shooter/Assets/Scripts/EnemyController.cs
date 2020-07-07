using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Reference to enemy Rigidbody
    private Rigidbody rb;

    // Movement speed of enemy
    public float moveSpeed;

    // Reference to player
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }

    // Fixed update used for physics object physics/movement
    void FixedUpdate()
    {
        rb.velocity = transform.forward * moveSpeed;
    }
}
