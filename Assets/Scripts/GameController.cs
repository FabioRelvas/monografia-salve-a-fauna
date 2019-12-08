using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Personagem")]
    public Transform tPlayer;
    public float playerSpeed;
    [Header("Configuração limite Movimento")]
    public float maxY;
    public float minY;
    public float maxX;
    public float minX;

    [Header("Configuração da GamePlay")]
    public float objSpeed;
    public float intervalSpawn;
    public int raiseSpeedAfterPoints;
    public float raiseTheSpeedIn;
    public float lowerTheIntervalIn;
    public int pointsForEachPoluition;
    public float maxSpeed;
    public float minInterval;

    [Header("Configuração das Poluições")]
    public GameObject[] prefabPoluition;

    public float posXPoluition;
    public float[] posYPoluition;

    public int orderPoluition;

    [Header("HUD")]
    public Text txtScore;
    int score;

    [Header("Controlador de FX")]
    public AudioSource sFx;
    public AudioClip fxScore;

    [Header("Nome das Poluições")]
    public string[] pol;

    void Start()
    {
        StartCoroutine("spawnPoluition");
    }


    IEnumerator spawnPoluition()
    {
        yield return new WaitForSeconds(intervalSpawn);

        int randSprite1 = Random.Range(0, 6);

        int randPos1 = Random.Range(0, 3);

        int randSprite2 = Random.Range(0, 6);

        int randPos2 = Random.Range(0, 3);

        if (randSprite1 == randSprite2 || randPos1 == randPos2)
        {
            while (randSprite1 == randSprite2)
            {
                randSprite2 = Random.Range(0, 6);
            }

            while (randPos1 == randPos2)
            {
                randPos2 = Random.Range(0, 3);
            }
        }

        // First Sprite
        GameObject tempPoluition = prefabPoluition[randSprite1];

        GameObject actualPoluition = Instantiate(tempPoluition);

        actualPoluition.transform.position = new Vector3(posXPoluition, posYPoluition[randPos1], 0);
        actualPoluition.GetComponent<SpriteRenderer>().sortingOrder = orderPoluition;


        // Second Sprite
        tempPoluition = prefabPoluition[randSprite2];

        actualPoluition = Instantiate(tempPoluition);

        actualPoluition.transform.position = new Vector3(posXPoluition, posYPoluition[randPos2], 0);
        actualPoluition.GetComponent<SpriteRenderer>().sortingOrder = orderPoluition;

        StartCoroutine("spawnPoluition");

    }

    public void scoreCount()
    {

        score += pointsForEachPoluition;

        txtScore.text = "PONTOS: " + score.ToString();

        sFx.PlayOneShot(fxScore);
    }

    public void levelUp()
    {
        if (score >= raiseSpeedAfterPoints)
        {
            if (objSpeed == maxSpeed || intervalSpawn == minInterval)
            {
                objSpeed += raiseTheSpeedIn;
                intervalSpawn += lowerTheIntervalIn;
                raiseSpeedAfterPoints += raiseSpeedAfterPoints;
            }
        }
    }

    public void gameOver(GameObject objCollider)
    {
        string obj = objCollider.ToString();
        int tempJ = -1;
        for (int j = 0; j < prefabPoluition.Length; j++)
        {
            if (Equals(obj, pol[j]))
            {
                tempJ = j;
            }
        }

        string temp = "";

        if (tempJ == 0)
            temp = "O petróleo é responsável pela grande intoxicação dos animais marinhos.";
        else if (tempJ == 1)
            temp = "Plásticos podem causar a morte por asfixia dos animais marinhos.";
        else if (tempJ == 2)
            temp = "Plásticos podem causar ferimentos profundos em animais marinhos.";
        else if (tempJ == 3)
            temp = "Microplásticos podem afetar a reprodução dos animais.";
        else if (tempJ == 4)
            temp = "Alguns tipos de plásticos podem perfurar o estômago dos animais ao serem ingeridos.";
        else if (tempJ == 5)
            temp = "Microplásticos podem aumentar a chance de doenças nos animais marinhos.";

        if (PlayerPrefs.GetInt("HighScore") < score)
            PlayerPrefs.SetInt("HighScore", score);

        PlayerPrefs.SetInt("deathScore", score);

        PlayerPrefs.SetString("deathText", temp);

        SceneManager.LoadScene("GameOver");
    }


}