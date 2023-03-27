using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData data;

    private float spawnTime = 0f;

    void Start()
    {
        spawnTime = Time.time;
        GetComponent<Rigidbody2D>().velocity = data.initialVelocity;
    }

    void Update()
    {
        if(Time.time - spawnTime >= data.lifetime)
            Destroy(gameObject);
    }
    
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.tag == data.enemyTag)
    //     {}        

    //     Destroy(gameObject);
    // }
}
