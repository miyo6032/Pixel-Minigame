using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for shooting projectiles.
public class ProjectileShooter : MonoBehaviour {

    public Projectile projectile;

    public float rotation;

    int coroutineRes = 10;

    PlayerStats playerStats;

    Rigidbody2D rb;

	public void Start () {
        playerStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ShootingRoutine());
    }

    IEnumerator ShootingRoutine()
    {
        while (GameManager.instance.GameOver())
        {
            yield return null;
        }
        while (!GameManager.instance.GameOver())
        {
            if (playerStats.Trishot()) {
                Trishot();
            }
            else
            {
                Quaternion angle = Quaternion.AngleAxis(rotation, Vector3.forward);
                Fire(angle);
            }
            for (int i = 0; i < coroutineRes; i++)
            {
                yield return new WaitForSeconds(playerStats.fireCooldown / coroutineRes);
            }
        }
    }

    //Shoots a circle of bullets
    public void Starburst()
    {
        for(int i = 0; i < 36; i++)
        {
            Quaternion angle = Quaternion.AngleAxis(i * 10, Vector3.forward);
            Fire(angle);
        }
    }

    //Shoots three bullets 15 degrees apart
    public void Trishot()
    {
        for (int i = 0; i < 3; i++)
        {
            Quaternion angle = Quaternion.AngleAxis(rotation - 15 + i * 15, Vector3.forward);
            Fire(angle);
        }
    }

    //Fires 1 bullet
    void Fire(Quaternion angle)
    {
        Projectile instance = Instantiate(projectile, transform.position, Quaternion.identity);
        instance.InitProjectile(angle, playerStats.fireSpeed, gameObject.tag, new Vector2(0, rb.velocity.y * 0.5f));
        instance.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
    }

}
