using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles various overall tasks such as game restarting, game over, and game initialization
public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public PlayerMovement playerMovement;

    public ShowGameOver winloseCanvas;

    public Vector2 player1Start;

    public Vector2 player2Start;

    bool gameOver = false;

	void Start () {
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        playerMovement = GetComponent<PlayerMovement>();

        Restart();
	}

    //Used by many classes to check whether they should be active or not
    public bool GameOver()
    {
        return gameOver;
    }
	
	public void EndGame(string losingPlayer)
    {
        gameOver = true;
        if(losingPlayer == "Player1")
            winloseCanvas.Activate("Player 2");
        else
            winloseCanvas.Activate("Player 1");
    }

    public void Restart()
    {
        playerMovement.player1.position = player1Start;
        playerMovement.player2.position = player2Start;
    }

}
