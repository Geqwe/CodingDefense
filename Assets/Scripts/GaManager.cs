using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GaManager : MonoBehaviour
{
    bool ended = false;
    public string nextLevel = "LevelSelect";
    public int levelToUnlock = 2;
    public Image darkFade;

    private void Start() {
        darkFade.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.Lives <= 0 && ended==false) {
            EndGame();
        }
    }

    void EndGame() {
        ended = true;
        Debug.Log("Game Over Try again");
    }

    public void WinLevel() {
        darkFade.enabled = true;
        darkFade.canvasRenderer.SetAlpha(0.0f);
        if(PlayerPrefs.GetInt("levelReached", 0) < levelToUnlock) {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        StartCoroutine(FadeCoroutine(nextLevel));
    }

    IEnumerator FadeCoroutine(string lvlName) {
        darkFade.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(lvlName);
    }
}
