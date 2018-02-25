using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    public GameObject[] powerupPrefabs;

    public int arenaSize;

    public int arenaHeight;

    void Start()
    {
        StartCoroutine(PowerupEnumerator());
    }

    IEnumerator PowerupEnumerator()
    {
        while (!GameManager.instance.GameOver())
        {
            SpawnPowerups();
            yield return new WaitForSeconds(8);
        }
    }

    void SpawnPowerups()
    {
        GameObject toInstantiate = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];

        Vector2 player2Powerup = new Vector2(Random.Range(1, arenaSize - 1) + 0.5f, Random.Range(0, 2) == 1 ? arenaHeight: -arenaHeight);
        Vector2 player1Powerup = new Vector2(Random.Range(-arenaSize + 2, -1) - 0.5f, Random.Range(0, 2) == 1 ? arenaHeight : -arenaHeight);

        Quaternion powerup1Direction = Quaternion.AngleAxis(-Mathf.Sign(player1Powerup.y) * 90, Vector3.forward);
        Quaternion powerup2Direction = Quaternion.AngleAxis(-Mathf.Sign(player2Powerup.y) * 90, Vector3.forward);

        Instantiate(toInstantiate, player1Powerup, powerup1Direction);
        Instantiate(toInstantiate, player2Powerup, powerup2Direction);

    }

}
