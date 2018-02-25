using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadySetGo : MonoBehaviour {

    public Text rsgText;

    string[] rsg = { "Get Ready...", "3...", "2...", "1..." };

    void Start()
    {
        StartCoroutine(RSG());
    }

    IEnumerator RSG()
    {
        for (int i = 0; i < 4; i++)
        {
            rsgText.text = rsg[i];
            yield return new WaitForSeconds(1);
        }
        GameManager.instance.StartGame();
        gameObject.SetActive(false);
    }
}
