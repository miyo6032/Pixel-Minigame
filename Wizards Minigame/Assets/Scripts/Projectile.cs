using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float initialAcceleration;

    public float maxSpeed;

    public string playerTag;

    Vector2 direction;

    Rigidbody2D rb;

    //Required to call this method to initialize all neccessary attributes of the probjectile. 
    public void InitProjectile(Quaternion dir, float speedFactor, string tag)
    {
        rb = GetComponent<Rigidbody2D>();
        initialAcceleration *= speedFactor;
        maxSpeed *= speedFactor;
        playerTag = tag;
        transform.rotation = dir;
        float bulletRotation = transform.rotation.eulerAngles.z;
        direction = new Vector2(Mathf.Cos(bulletRotation * Mathf.Deg2Rad), Mathf.Sin(bulletRotation * Mathf.Deg2Rad));
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
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ProjectileBound")
        {
            Impact();
        }
    }

}
