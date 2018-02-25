using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Responsible for spawning the powerups in the game
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
        while (GameManager.instance.GameOver())
        {
            yield return null;
        }
        while (!GameManager.instance.GameOver())
        {
            SpawnPowerups();
            yield return new WaitForSeconds(8);
        }
    }

    //Spawns powerups starting at either the top or bottom of the arena. Then calculates the correct direction the powerup should
    //face in order to move in the right direction.
    void SpawnPowerups()
    {
        GameObject instance1 = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
        GameObject instance2 = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];

        Vector2 player2Powerup = new Vector2(Random.Range(1, arenaSize - 1) + 0.5f, Random.Range(0, 2) == 1 ? arenaHeight: -arenaHeight);
        Vector2 player1Powerup = new Vector2(Random.Range(-arenaSize + 2, -1) - 0.5f, Random.Range(0, 2) == 1 ? arenaHeight : -arenaHeight);

        Quaternion powerup1Direction = Quaternion.AngleAxis(-Mathf.Sign(player1Powerup.y) * 90, Vector3.forward);
        Quaternion powerup2Direction = Quaternion.AngleAxis(-Mathf.Sign(player2Powerup.y) * 90, Vector3.forward);

        Instantiate(instance1, player1Powerup, powerup1Direction);
        Instantiate(instance2, player2Powerup, powerup2Direction);

    }

}
