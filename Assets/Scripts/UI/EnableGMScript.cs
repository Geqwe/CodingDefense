using UnityEngine;

public class EnableGMScript : MonoBehaviour
{
    public GameObject GM;
    public GameObject playButton;
    
    public void EnableGM() {
        GM.SetActive(true);
        playButton.SetActive(false);
    }
}
