using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to each player to detect incomming projectile collisions
public class HitProjectile : MonoBehaviour
{

    PlayerStats playerStats;
    ProjectileShooter projectileShooter;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        projectileShooter = GetComponent<ProjectileShooter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Projectile incoming = other.gameObject.GetComponent<Projectile>();
            if (incoming.playerTag != gameObject.tag)//Used to make sure the player doens't hit itself
            {
                if (!GameManager.instance.GameOver())
                    GameManager.instance.EndGame(gameObject.tag);
                incoming.Impact();
            }
        }
        else if(other.gameObject.tag == "Fire Cooldown Up")
        {
            playerStats.FireCooldownUp();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Fire Speed Up")
        {
            playerStats.FireSpeedUp();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Starburst")
        {
            projectileShooter.Starburst();
            Destroy(other.gameObject);
        }
    }

}
