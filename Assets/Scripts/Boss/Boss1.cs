using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
public class Boss1 : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private Transform target;

    private BossDialog bossDialog;

    public int i;

    public GameObject laserPrefab;
    public GameObject beamPrefab;

    private Player player;

    private Vector3 leftFire;
    private Vector3 rightFire;

    public int health = 150;
    public SpriteRenderer _renderer;

    public Slider slider;

    public Transform[] explosionLocations;
    public GameObject exlodePrefab;
    public GameObject bigExplosion;

    public bool isDead;

    public GameObject youWinPanel;
    private SpawnManager spawnManager;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()

    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        bossDialog = GetComponent<BossDialog>();
        _renderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0, 16, 0); //Spawn above screen bounds.
        leftFire = new Vector3(-4, -4, 0);
        rightFire = new Vector3(4, -4, 0);
        isDead = false;
        healthBar.SetActive(true);
        StartCoroutine(WaitToFire());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            if(isDead == false)
            {
                Damage();
            }

            else if(isDead == true)
            {
                return;
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health >= 0.1f)
        {
            Movement();
        }
    }

    public void Movement()
    {
        target = waypoints[i];
        float distance = Vector3.Distance(transform.position, target.position);
        target.position = waypoints[i].position;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (distance <= 0.5f)
        {
            if (target.position == waypoints[0].position)
            {
                i++;
            }

            if (target.position == waypoints[2].position)
            {
                i--;
            }

            if (target.position == waypoints[1].position)
            {
                i++;
            }
        }
    }

    public void Fire()
    {
        StartCoroutine(LeftFireRoutine());
        StartCoroutine(RightFireRoutine());
        StartCoroutine(FireBeamRoutine());
    }

    IEnumerator LeftFireRoutine()
    {
        while(GameManager.Instance.isGameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(2.5f, 5));
            Instantiate(laserPrefab, transform.position + leftFire, Quaternion.identity);
        }
    }

    IEnumerator RightFireRoutine()
    {
        while (GameManager.Instance.isGameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            Instantiate(laserPrefab, transform.position + rightFire, Quaternion.identity);
        }
    }
    IEnumerator FireBeamRoutine()
    {
        while (GameManager.Instance.isGameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(10,15));
            beamPrefab.SetActive(true);
            yield return new WaitForSeconds(5f);
            beamPrefab.SetActive(false);        
        }
    }

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(7.0f);
        Fire();
    }

    public void Damage()
    {
        health--;
        slider.value = slider.value - 0.006666667f;
        StartCoroutine(colorFlashHit());

        if (health <= 0)
        {
            isDead = true;
                slider.value = 0;
                Destroy(this.gameObject, 10f);
                StartCoroutine(ExplodeRoutine());
            StartCoroutine(BigExplosion());
        }

    }

    IEnumerator colorFlashHit()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _renderer.color = Color.white;
    }

    IEnumerator ExplodeRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(exlodePrefab, explosionLocations[0].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(exlodePrefab, explosionLocations[1].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(exlodePrefab, explosionLocations[2].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(exlodePrefab, explosionLocations[3].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(exlodePrefab, explosionLocations[0].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(exlodePrefab, explosionLocations[1].position, Quaternion.identity);
    }

    IEnumerator BigExplosion()
    {
        spawnManager.StopSpawning();
        yield return new WaitForSeconds(9f);

        Instantiate(bigExplosion, transform.position, Quaternion.identity);
        youWinPanel.SetActive(true);
        healthBar.SetActive(false);
        GameManager.Instance.gameWon = true;
    }
}
