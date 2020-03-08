using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform spawnpoint;
    [SerializeField] Text waveNumberText; //will be used to display the current wave OR timer text
    [SerializeField] float timeBetweenWaves = 10f;

    private float countdown = 2f;
    private int waveNumber = 1;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}
