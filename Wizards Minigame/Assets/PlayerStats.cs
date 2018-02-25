﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float fireCooldown;
    public float fireSpeed;

    float powerupTime = 5;

    float fireCooldownEffect = 3;
    float fireSpeedPowerupEffect = 3;

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