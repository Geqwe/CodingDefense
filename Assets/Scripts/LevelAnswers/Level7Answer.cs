using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level7Answer : MonoBehaviour
{
    public InputField inputField1;
    public InputField inputField2;
    public Text textSuccess;
    bool check1 = false;
    bool check2 = false;
    public GameObject playButton;
    string textSucc = "";
    public GameObject buildMan;

    // Start is called before the first frame update
    void Start()
    {
        textSucc = textSuccess.text;
        PlayerStats.Money = 250;
        PlayerStats.Lives = 3;
    }

    public void CheckValues() {
        if(inputField1.text == "enemyHealth") {
            textSuccess.text = "You got the first one right\n"+ textSucc; 
            check1 = true;
        }
        else {
            textSuccess.text = "You got the first one wrong (name of the variable)\n"+ textSucc; 
            check1 = false;
        }

        if(inputField2.text == "0") {
            textSuccess.text = "You got the second one right\n"+ textSucc; 
            check2 = true;
        }
        else {
            if(check1==false) {
                textSuccess.text = "You got the second one wrong (less or equal than this value)\n"+ textSuccess.text; 
            }
            else {
                textSuccess.text = "You got the second one wrong (less or equal than this value)\n"+ textSucc; 
            }
            check2 = false;
        }

        if(check1==true && check2==true) {
            playButton.SetActive(true);
            textSuccess.text = "Very well\nClick on the turret and place it on some block on the screen. \nTry not to lose all of your lives. \nI believe in you. \nHit play when you're ready;";
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
