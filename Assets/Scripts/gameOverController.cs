using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverController : MonoBehaviour
{
    [Header("Textos")]
    public Text txtGameOver;

    public Text highscoreTxt;


    void Start()
    {
        txtGameOver.text = PlayerPrefs.GetString("deathText");
        highscoreTxt.text = "Pontuação: " + PlayerPrefs.GetInt("deathScore");
    }

}
