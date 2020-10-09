using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image darkFade;

    private void Start() {
        darkFade.enabled = false;
    }

    public void PlayGame()
    {
        darkFade.enabled = true;
        darkFade.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(FadeCoroutine());
    }

    public void GoToLevels() {
        
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    IEnumerator FadeCoroutine() {
        darkFade.CrossFadeAlpha(1,3,false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
