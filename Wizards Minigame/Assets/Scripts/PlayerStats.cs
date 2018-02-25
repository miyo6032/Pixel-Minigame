using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles all of the realtime effects 
public class PlayerStats : MonoBehaviour {

    public float fireCooldown;
    public float fireSpeed;

    float powerupTime = 5;

    float fireCooldownEffect = 3;
    float fireSpeedPowerupEffect = 3;
    bool trishotEffect = false;

    //Called by the projectile shooter to check whether it should shoot trishot
    public bool Trishot()
    {
        return trishotEffect;
    }

    //Activates the trishot effect for a limited time
    public void ActivateTrishot()
    {
        trishotEffect = true;
        Invoke("DeactivateTrishot", powerupTime);
    }

    public void DeactivateTrishot()
    {
        trishotEffect = false;
    }

    //Activates cooldown powerup
    public void FireCooldownUp()
    {
        fireCooldown /= fireCooldownEffect;
        Invoke("FireCooldownDown", powerupTime);
    }

    void FireCooldownDown()
    {
        fireCooldown *= fireCooldownEffect;
    }

    public void FireSpeedUp()
    {
        fireSpeed *= fireSpeedPowerupEffect;
        Invoke("FireSpeedDown", powerupTime);
    }

    void FireSpeedDown()
    {
        fireSpeed /= fireSpeedPowerupEffect;
    }
}
