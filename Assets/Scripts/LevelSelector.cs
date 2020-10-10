using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelSelector : MonoBehaviour
{
    public Image darkFade;
    public Button[] levelButtons;

    private void Start() {
        darkFade.enabled = false;
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if(i>levelReached) {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string levelName) {
        darkFade.enabled = true;
        darkFade.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(FadeCoroutine(levelName));
    }

    IEnumerator FadeCoroutine(string lvlName) {
        darkFade.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(lvlName);
    }
}
