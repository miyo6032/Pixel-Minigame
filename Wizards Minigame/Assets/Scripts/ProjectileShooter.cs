using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for shooting projectiles.
public class ProjectileShooter : MonoBehaviour {

    public Projectile projectile;

    public float rotation;

    int coroutineRes = 10;

    PlayerStats playerStats;

	public void Start () {
        playerStats = GetComponent<PlayerStats>();
        StartCoroutine(ShootingRoutine());
	}

    IEnumerator ShootingRoutine()
    {
        while (!GameManager.instance.GameOver())
        {
            Fire();
            for (int i = 0; i < coroutineRes; i++)
            {
                yield return new WaitForSeconds(playerStats.fireCooldown / coroutineRes);
            }
        }
    }

    public void Starburst()
    {
        for(int i = 0; i < 36; i++)
        {
            Quaternion angle = Quaternion.AngleAxis(i * 10, Vector3.forward);
            Projectile instance = Instantiate(projectile, transform.position, angle);
            instance.InitProjectile(angle, playerStats.fireSpeed, gameObject.tag);
            instance.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
        }
    }

    void Fire()
    {
        Quaternion angle = Quaternion.AngleAxis(rotation, Vector3.forward);
        Projectile instance = Instantiate(projectile, transform.position, Quaternion.identity);
        instance.InitProjectile(angle, playerStats.fireSpeed, gameObject.tag);
        instance.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
    }

}
