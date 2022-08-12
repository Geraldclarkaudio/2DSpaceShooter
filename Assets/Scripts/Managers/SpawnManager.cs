using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUpContainer;
    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private int[] puWeights;


    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int[] enemyWeights;

    [SerializeField]
    private GameObject bossEnemy1;

    [SerializeField]
    private int enemiesSpawned = 0;
    public int enemiesDestroyed;
    public int wave;

    public bool playerDied = false;

    [SerializeField]
    private GameObject wonGameMusic;
    [SerializeField]
    private GameObject BGM;
    //public AK.Wwise.Event music;
    //public AK.Wwise.Event stinger;


    private UIManager uiManager;

    public string[] switchGroupName;
    public string[] switchName;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        //music.Post(gameObject);
        wave = 1;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(PowerUpSpawner());

        if (wave <= 3)
        {
            uiManager.UpdateWaveText("WAVE " + wave);
        }

        else if (wave > 3)
        {
            uiManager.UpdateWaveText("BOSS FIGHT");
        }
        //stinger.Post(gameObject);
        //AkSoundEngine.SetSwitch(switchGroupName[wave - 1], switchName[1], gameObject);
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawnEnemies());
        StopCoroutine(PowerUpSpawner());
        /// StopAllCoroutines();
    }
    public void PlayerDied()
    {
        playerDied = true;
        Destroy(enemyContainer);
        //music.Stop(gameObject);
    }

    IEnumerator PowerUpSpawner() //POWER UPS
    {
        yield return new WaitForSeconds(2.0f);
        while (playerDied == false)
        {
            Vector3 posToSPawn = new Vector3(Random.Range(-15f, 15f), 9, 0);
            //int randomPowerUp = Random.Range(0, 6);
            GameObject newPowerUp = Instantiate(powerups[GetRandomPowerUp(puWeights)], posToSPawn, Quaternion.identity);
            newPowerUp.transform.parent = powerUpContainer.transform;
            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }
    }
    //Spawns Powerups dependednt on their weight value.

    IEnumerator SpawnEnemies()//ENEMIES
    {
        yield return new WaitForSeconds(1.0f);

        while (playerDied == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-15f, 15f), 9, 0);
            GameObject newEnemy = Instantiate(enemies[GetRandomEnemy(enemyWeights)], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            if (wave == 1)
            {
                yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
            }
            if (wave == 2)
            {
                yield return new WaitForSeconds(Random.Range(1.0f, 1.75f));
            }
            if (wave == 3)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
            }

            enemiesSpawned++;

            if (enemiesSpawned == 5 && wave == 1)
            {
                StartCoroutine(WaveChanger());
                yield break;
            }

            if (enemiesSpawned == 10 && wave == 2)
            {
                StartCoroutine(WaveChanger());
                yield break;
            }

            if (enemiesSpawned == 15 && wave == 3)
            {
                StartCoroutine(WaveChanger());
                yield break;
            }

            if(wave == 4)
            {
                StopAllCoroutines();
                SpawnBoss();
                StartCoroutine(PowerUpSpawner());
                yield break;
            }
        }

    } // Spawns Enemies dependent on their weight value. 

    public void SpawnBoss()
    {
        StopAllCoroutines();
        StartCoroutine(PowerUpSpawner());
        bossEnemy1.SetActive(true);
    }
    IEnumerator WaveChanger()
    {
        StopSpawning();
        yield return new WaitForSeconds(5.0f);
        wave++;
        enemiesSpawned = 0;
        StartSpawning();
    }

    public int GetRandomPowerUp(int[] Weights)
    {
        int sumOfWeights = 0;
        int randNum;

        for (int i = 0; i < powerups.Length; i++)
        {
            sumOfWeights += Weights[i];
        }

        randNum = Random.Range(0, sumOfWeights);

        for (int i = 0; i < puWeights.Length; i++)
        {
            if (randNum < puWeights[i])
            {
                return i;
            }

            randNum -= puWeights[i];
        }

        return -1;
    }

    public int GetRandomEnemy(int[] Weights)
    {
        int sumOfWeights = 0;
        int randNum;

        for (int i = 0; i < enemies.Length; i++)
        {
            sumOfWeights += Weights[i];
        }

        randNum = Random.Range(0, sumOfWeights);

        for(int i = 0; i < enemyWeights.Length; i++)
        {
            if(randNum < enemyWeights[i])
            {
                return i;
            }

            randNum -= enemyWeights[i];
        }

        return -1;
    }

    public void Update()
    {
        if(GameManager.Instance.gameWon == true)
        {
            //music.Stop(gameObject);
            BGM.SetActive(false);
            wonGameMusic.SetActive(true);
        }
    }
}
