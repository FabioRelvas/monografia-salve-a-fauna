using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mainMenu : MonoBehaviour
{
    public static bool isShow = false;
    public GameObject helpMenuUI;
    public Text highscoreTxt;

    void Start()
    {
        helpMenuUI.SetActive(false);
        highscoreTxt.gameObject.SetActive(true);
        highscoreTxt.text = "Maior Pontuação: " + PlayerPrefs.GetInt("HighScore");
    }

    public void hideHelp()
    {
        helpMenuUI.SetActive(false);
        isShow = false;
        highscoreTxt.gameObject.SetActive(true);
    }

    public void showHelp()
    {
        helpMenuUI.SetActive(true);
        isShow = true;
        highscoreTxt.gameObject.SetActive(false);
    }
}
