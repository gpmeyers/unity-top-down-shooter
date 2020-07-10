using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransLocController : MonoBehaviour
{
    private PlayerController player;

    private GunController gun;

    public float speed;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        gun = FindObjectOfType<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(1))
        {
            player.transform.position = transform.position;
            gun.transLocFired = false;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gun.transLocFired = false;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            gun.transLocFired = false;
            Destroy(gameObject);
        }
    }
}
