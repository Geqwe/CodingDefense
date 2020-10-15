using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Answer : MonoBehaviour
{
    public GameObject inputField;
    public Text textSuccess;
    public GameObject buildMan;

    public void CheckString() {
        if(inputField.GetComponent<Text>().text == "Lesson3") {
            textSuccess.text = "Very Well";
            buildMan.GetComponent<GaManager>().WinLevel();
        }
        else {
            textSuccess.text = "Try Again \n" + textSuccess.text;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
