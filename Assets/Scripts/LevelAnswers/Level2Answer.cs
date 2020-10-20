using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Answer : MonoBehaviour
{
    public InputField inputField;
    public Text textSuccess;
    public GameObject buildMan;
    public Text textToSee;
    bool clicked = false;
    public GameObject text1;
    public GameObject text2;

    public void CheckString() {
        if(!clicked) {
            string check = inputField.text;
            Debug.Log(check[0]+" "+check[check.Length-1]);
            if((check[0]=='"') && (check[check.Length-1]=='"')) {
                textToSee.text = check.Substring(1,check.Length-2);
                textSuccess.text = "Now, write what that will print: \n"+"std::cout << \"sean\";";
                clicked = true;
                text1.SetActive(false);
                text2.SetActive(false);
            }
            else {
                textSuccess.text = "What you write must be inside quotes(\" \") \n" + textSuccess.text;
            }
            
        }
        else {
            if(inputField.text == "sean") {
                textSuccess.text = "Very Well";
                buildMan.GetComponent<GaManager>().WinLevel();
            }
            else {
                textSuccess.text = "Try Again(maybe without the quotes) \n" + textSuccess.text;
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
