using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float initialAcceleration;

    public float maxSpeed;

    public string playerTag;

    Rigidbody2D rb;

    Vector2 direction;

    //Required to call this method to initialize all neccessary attributes of the probjectile. 
    public void InitProjectile(Vector2 dir, float speedFactor, string tag)
    {
        rb = GetComponent<Rigidbody2D>();
        initialAcceleration *= speedFactor;
        maxSpeed *= speedFactor;
        playerTag = tag;
        direction  = dir;
    }

    void FixedUpdate()
    {
        //Responsible for a bit of acceleration
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(direction * initialAcceleration);
        }
    }

    public void Impact()
    {
        Destroy(gameObject);
    }

    //Destroy when the projectile goes out of bounds
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ProjectileBound")
        {
            Impact();
        }
    }

}
