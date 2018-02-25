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

        Vector2 player1Powerup = new Vector2(Random.Range(1, arenaSize - 1), arenaHeight);
        Vector2 player2Powerup = new Vector2(Random.Range(-arenaSize + 2, -1), arenaHeight);

        Instantiate(toInstantiate, player1Powerup, Quaternion.identity);
        Instantiate(toInstantiate, player2Powerup, Quaternion.identity);

    }

}
