using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public class Level4Answer : MonoBehaviour
{
    public InputField inputField;
    public Text textSuccess;
    public GameObject buildMan;
    int clicked = 0;
    public Text text1;
    // PlayerStats plStats;
    public Text baseName;
    public GameObject playButton;
    string textSucc = "yolo";

    private void Start() {
        textSucc = textSuccess.text;
    }

    public void CheckString() {
        string check = inputField.text;
        if(clicked == 0) {
            if(int.TryParse(check, out int yolo)) {
                PlayerStats.Lives = int.Parse(check);
                text1.text = "double money = ";
                textSuccess.text = textSucc;
                clicked = 1;
            }
            else {
                textSuccess.text = "Write an integer (1, 3, 10) \n"+ textSucc;
            }
            
        }
        else if(clicked == 1) {
            if(double.TryParse(check, out double yolo1) && check.Contains(".")) {
                PlayerStats.Money = double.Parse(check, CultureInfo.InvariantCulture);
                text1.text = "string baseName = ";
                textSuccess.text = textSucc;
                clicked = 2;
            }
            else {
                textSuccess.text = "Write an double (1.2, 3.99, 10.00010101) \n"+ textSucc;
            }
        }
        else if(clicked == 2) {
            if((check[0]=='"') && (check[check.Length-1]=='"')) {
                baseName.text = check.Substring(1,check.Length-2);
                playButton.SetActive(true);
                clicked = 3;
                textSuccess.text = " Click on the turret and place it on some block on the screen. \n Try not to lose all of your lives. \n I believe in you. \n Hit play when you're ready";
            }
            else {
                textSuccess.text = "What you write must be inside quotes(' ') \n " + textSucc;
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
