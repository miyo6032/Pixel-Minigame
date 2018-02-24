using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for shooting projectiles.
public class ProjectileShooter : MonoBehaviour {

    public Projectile fireball;

    public float fireCooldown;

    public Vector2 fireDir;

	public void Start () {
        StartCoroutine(ShootingRoutine());
	}

    IEnumerator ShootingRoutine()
    {
        while (!GameManager.instance.GameOver())
        {
            Fire();
            yield return new WaitForSeconds(fireCooldown);
        }
    }

    void Fire()
    {
        Projectile instance = Instantiate(fireball, transform.position, Quaternion.identity);
        instance.InitProjectile(fireDir, 1, gameObject.tag);
        instance.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
    }

}
