using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject skipButton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine() {
        yield return new WaitForSeconds(8);
        skipButton.SetActive(true);
    }

    private void Update() {
        if(Input.GetKeyDown("space")) {
            gotoMainMenu();
        }
    }

    public void gotoMainMenu() {
        SceneManager.LoadScene(0);
    }
}
