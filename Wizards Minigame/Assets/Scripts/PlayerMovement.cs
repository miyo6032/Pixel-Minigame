using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float baseMoveSpeed = 1f;

    public Rigidbody2D player1;

    public Rigidbody2D player2;
	
	void Update () {
        if (!GameManager.instance.GameOver())
        {
            float horz1 = Input.GetAxis("Horizontal1");
            float vert1 = Input.GetAxis("Vertical1");

            player1.velocity = new Vector2(horz1, vert1) * baseMoveSpeed;

            float horz2 = Input.GetAxis("Horizontal2");
            float vert2 = Input.GetAxis("Vertical2");

            player2.velocity = new Vector2(horz2, vert2) * baseMoveSpeed;
        }
        else
        {
            player1.velocity = Vector2.zero;
            player2.velocity = Vector2.zero;
        }
    }
}
