﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Answer : MonoBehaviour
{
    public InputField inputField;
    public Text textSuccess;
    public GameObject buildMan;

    public void CheckString() {
        if(inputField.text == "include") {
            textSuccess.text = "Very Well";
            buildMan.GetComponent<GaManager>().WinLevel();
        }
        else {
            textSuccess.text = "Try Again \n"+ textSuccess.text;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
