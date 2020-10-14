using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Answer : MonoBehaviour
{
    public GameObject inputField;
    public Text textSuccess;
    public GameObject buildMan;

    public void CheckString() {
        textSuccess.text = inputField.GetComponent<Text>().text;
        buildMan.GetComponent<GaManager>().WinLevel();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
