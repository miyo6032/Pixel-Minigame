using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMovement : MonoBehaviour {

    Rigidbody2D rb;

    Vector2 direction;

    public float maxSpeed;

    public float initialAcceleration;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

}
