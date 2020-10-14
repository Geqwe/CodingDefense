using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingTextScript : MonoBehaviour
{
    public Text textHere;
    Color startColor;
    Color black = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        startColor = textHere.color;
        StartCoroutine("FlashText");
    }

    IEnumerator FlashText() {
        while(true) {
            if(textHere.color == startColor) {
                textHere.color = black;
                yield return new WaitForSeconds(0.5f);
            }
            else if(textHere.color == black) {
                textHere.color = startColor;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
