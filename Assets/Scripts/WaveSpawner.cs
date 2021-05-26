using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public static int enemeiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves;
    private float countdown;
    public GameManager gameManager;
    private int waveNumber = 0;
    public Text nextWaveText;
    void Update()
    {
        if (enemeiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {            
            gameManager.GameWon();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            nextWaveText.text = "";
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        nextWaveText.text = string.Format("Next in: {0:00.00}", countdown);
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
    }
 
 void DestroyAllEnemies(){
 
    GameObject[] enemies =  GameObject.FindGameObjectsWithTag ("Enemy");
 
     foreach(GameObject enemy in enemies)
         Destroy(enemy);

        enemeiesAlive = 0;
 }
}
