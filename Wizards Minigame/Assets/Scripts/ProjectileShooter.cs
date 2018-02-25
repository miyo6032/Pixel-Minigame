using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for shooting projectiles.
public class ProjectileShooter : MonoBehaviour {

    public Projectile projectile;

    public Vector2 fireDir;

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

    void Fire()
    {
        Projectile instance = Instantiate(projectile, transform.position, Quaternion.identity);
        instance.InitProjectile(fireDir, playerStats.fireSpeed, gameObject.tag);
        instance.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
    }

}
