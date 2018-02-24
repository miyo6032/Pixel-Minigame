using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to each player to detect incomming projectile collisions
public class HitProjectile : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.instance.GameOver())
            if (other.gameObject.tag == "Projectile")
            {
                Projectile incoming = other.gameObject.GetComponent<Projectile>();
                if (incoming.playerTag != gameObject.tag)//Used to make sure the player doens't hit itself
                {
                    incoming.Impact();
                }
            }
    }

}
