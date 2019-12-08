using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class commands : MonoBehaviour
{

    public GameObject toggle;

    Toggle musicToggle;

    void Start()
    {
        musicToggle = toggle.GetComponent<Toggle>();
        checkToggle();
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void callScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void checkToggle()
    {
        if (AudioListener.pause)
        {
            musicToggle.isOn = true;
            AudioListener.pause = true;
        }
        else
        {
            musicToggle.isOn = false;
            AudioListener.pause = false;
        }
    }
}
