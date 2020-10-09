using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    bool ended = false;
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
}
