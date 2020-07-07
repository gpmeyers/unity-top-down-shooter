using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;

    public float lifeTime;

    public int bulletDamage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Logic for despawning bullets after a specified amount of time to save memory

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(bulletDamage);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
