using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform HumveePrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;
    private float timeToWait = 0.25f;

    public Text waveNumText;

    private int numOfEnemies = 0;
    public int waveNum = 0;

    void Update()
    {
        if (countDown <= 0) //so if our timer has reached zero then start spawning the enemies
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime; //count down timer

        waveNumText.text = waveNum.ToString();
    }

    IEnumerator SpawnWave() //creating coroutine so that the waves enemies don't just spawn on top of each other
    {
        numOfEnemies++;
        waveNum++;
        PlayerStats.Rounds++;

        for (int i = 0; i < numOfEnemies; i++)
        {
            SpawnEnemy();  
            yield return new WaitForSeconds(timeToWait);
        }
    }

    void SpawnEnemy()
    {
            Instantiate(HumveePrefab, spawnPoint.position, spawnPoint.rotation);
        
    }
}
