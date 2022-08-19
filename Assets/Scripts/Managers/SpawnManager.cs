using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _powerUpContainer;
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private int[] _puWeights;


    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private int[] _enemyWeights;

    [SerializeField]
    private GameObject _bossEnemy1;

    [SerializeField]
    private int _enemiesSpawned = 0;
    public int _enemiesDestroyed;
    public int wave;

    public bool playerDied = false;

    [SerializeField]
    private GameObject _wonGameMusic;
    [SerializeField]
    private GameObject _BGM;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        wave = 1;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(PowerUpSpawner());

        if (wave <= 3)
        {
            _uiManager.UpdateWaveText("WAVE " + wave);
        }

        else if (wave > 3)
        {
            _uiManager.UpdateWaveText("BOSS FIGHT");
        }

    }

    public void StopSpawning()
    {
        Debug.Log("StopSpawning");
        StopCoroutine(SpawnEnemies());
        StopCoroutine(PowerUpSpawner());
    }
    public void PlayerDied()
    {
        playerDied = true;
        Destroy(_enemyContainer);
    }

    IEnumerator PowerUpSpawner() //POWER UPS
    {
        yield return new WaitForSeconds(2.0f);
        while (playerDied == false)
        {
            Vector3 posToSPawn = new Vector3(Random.Range(-15f, 15f), 9, 0);
             GameObject newPowerUp = Instantiate(_powerups[GetRandomPowerUp(_puWeights)], posToSPawn, Quaternion.identity);
            newPowerUp.transform.parent = _powerUpContainer.transform;
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
            GameObject newEnemy = Instantiate(_enemies[GetRandomEnemy(_enemyWeights)], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            _enemiesSpawned++;

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



            if (_enemiesSpawned == 5 && wave == 1)
            {
                StartCoroutine(WaveChanger());
                yield break;
            }

            if (_enemiesSpawned == 10 && wave == 2)
            {
                StartCoroutine(WaveChanger());
                yield break;
            }

            if (_enemiesSpawned == 15 && wave == 3)
            {
                StartCoroutine(ChangeWaveToBoss());
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

    IEnumerator WaveChanger()
    {
        Debug.Log("Wave Changer");
        StopSpawning();
        yield return new WaitForSeconds(10.0f);
        wave++;
        _enemiesSpawned = 0;
        StartSpawning();
    }

    IEnumerator ChangeWaveToBoss()
    {
        Debug.Log("Wave Changer to Boss");
        StopSpawning();
        yield return new WaitForSeconds(30.0f);
        wave++;
        _enemiesSpawned = 0;
        StartSpawning();
    }

    public void SpawnBoss()
    {
        StopAllCoroutines();
        StartCoroutine(PowerUpSpawner());
        _bossEnemy1.SetActive(true);
    }


    public int GetRandomPowerUp(int[] Weights)
    {
        int sumOfWeights = 0;
        int randNum;

        for (int i = 0; i < _powerups.Length; i++)
        {
            sumOfWeights += Weights[i];
        }

        randNum = Random.Range(0, sumOfWeights);

        for (int i = 0; i < _puWeights.Length; i++)
        {
            if (randNum < _puWeights[i])
            {
                return i;
            }

            randNum -= _puWeights[i];
        }

        return -1;
    }

    public int GetRandomEnemy(int[] Weights)
    {
        int sumOfWeights = 0;
        int randNum;

        for (int i = 0; i < _enemies.Length; i++)
        {
            sumOfWeights += Weights[i];
        }

        randNum = Random.Range(0, sumOfWeights);

        for(int i = 0; i < _enemyWeights.Length; i++)
        {
            if(randNum < _enemyWeights[i])
            {
                return i;
            }

            randNum -= _enemyWeights[i];
        }

        return -1;
    }

    public void Update()
    {
        if(GameManager.Instance.gameWon == true)
        {
            _BGM.SetActive(false);
            _wonGameMusic.SetActive(true);
        }
    }
}
