﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public static int Lives;
    private int startLives = 3;

    private void Start() {
        Money = startMoney;
        Lives = startLives;
    }
}
