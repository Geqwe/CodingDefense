using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    private float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNum = 0;
    public Transform spawnPoint;
    public Text waveCountDownText;
    public Wave[] waves;

    private void Update() {
        if(EnemiesAlive > 0) {
            return;
        }
        if(countdown <= 0f) {
            StartCoroutine("SpawnWave");
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave() {
        Wave wave = waves[waveNum];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNum++;
    }

    void SpawnEnemy(GameObject enemyPref) {
        Instantiate(enemyPref, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
