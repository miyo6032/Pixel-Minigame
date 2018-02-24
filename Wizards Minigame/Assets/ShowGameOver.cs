﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Responsible for handling the game over gui - activated from the GameManager
public class ShowGameOver : MonoBehaviour {

    Text winText;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Activate(string winner)
    {
        gameObject.SetActive(true);
        winText.text = winner + " wins!";
    }

}
