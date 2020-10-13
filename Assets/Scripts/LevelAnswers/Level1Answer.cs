using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Answer : MonoBehaviour
{
    public GameObject inputField;
    public Text textSuccess;
    public GameObject buildMan;

    public void CheckString() {
        if(inputField.GetComponent<Text>().text == "include") {
            textSuccess.text = "Very Well";
            buildMan.GetComponent<GaManager>().WinLevel();
        }
        else {
            textSuccess.text = "Try Again";
        }
    }
}
