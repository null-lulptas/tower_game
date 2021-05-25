using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public static int enemeiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 7f;
    private float countdown = 2f;
    public GameManager gameManager;
    private int waveNumber = 0;
    void Update()
    {
        //Debug.Log("ALIVE" + enemeiesAlive);
        if (enemeiesAlive > 0)
        {
            return;
        }

        Debug.Log(waveNumber);
        if (waveNumber == waves.Length)
        {            
            gameManager.GameWon();
            DestroyAllEnemies();
            this.enabled = false;
        }

        if (countdown <= 0f)

        {
            if (PlayerStats.lives > 0)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }

        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];
        enemeiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveNumber++;       
    }
    void SpawnEnemy(GameObject enemy)
    {
        Quaternion rotation = Quaternion.Euler(0, 90, 0);
        Instantiate(enemy, spawnPoint.position, rotation);
        enemeiesAlive++;
    }
 
 void DestroyAllEnemies(){
 
    GameObject[] enemies =  GameObject.FindGameObjectsWithTag ("Enemy");
 
     foreach(GameObject enemy in enemies)
         Destroy(enemy);

        enemeiesAlive = 0;
 }
}
