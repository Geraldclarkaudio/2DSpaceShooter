using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Player _player;
    private Animator _anim;
    private BoxCollider2D col;
    private Animator camAnim;

    [SerializeField]
    private GameObject enemyLaser;

    private float _fireRate = 3;
    private float _canFire = -1f;

    public AK.Wwise.Event destroyed;

    private SpawnManager spawnManager;

    [SerializeField]
    private GameObject shields;

    private bool randomBool;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is Null");
        }
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        randomBool = Random.value > 0.5f;
        shields.SetActive(randomBool);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {  
            //sets 10 pointsd for killing this enemy. 
            //Make switch statement to call which enemy was killed. <3 
            if(shields.activeSelf == true)
            {
                shields.SetActive(false);
                return;
            }
            else if (shields.activeSelf == false)
            {
                _anim.SetBool("Hit", true);
                _player.ScoreKeeper(10);
                col.enabled = false;
                destroyed.Post(gameObject);
                spawnManager.enemiesDestroyed++;
                Destroy(this.gameObject, 2.5f);
            }
  
        }

        if (other.CompareTag("Missle"))
        {
            //sets 10 pointsd for killing this enemy. 
            //Make switch statement to call which enemy was killed. <3 
            if (shields.activeSelf == true)
            {
                shields.SetActive(false);
                return;
            }
            else if (shields.activeSelf == false)
            {
                _anim.SetBool("Hit", true);
                _player.ScoreKeeper(10);
                col.enabled = false;
                destroyed.Post(gameObject);
                spawnManager.enemiesDestroyed++;
                Destroy(this.gameObject, 2.5f);
            }

        }

        if (other.CompareTag("Player"))
        {
            _anim.SetBool("Hit", true);
            destroyed.Post(gameObject);
            camAnim.SetTrigger("Shake");
            spawnManager.enemiesDestroyed++;
            Destroy(this.gameObject, 2.5f); 
            _player.Damage();
        }

        if(other.CompareTag("ShieldPowerUp"))
        {
            shields.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    void Update()
    {
        Movement();

        if(Time.time >_canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
           GameObject enemyLaserGo = Instantiate(enemyLaser, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaserGo.GetComponentsInChildren<Laser>();
            //lasers[0].AssignEnemyLaser();
           // lasers[1].AssignEnemyLaser();
           //this also means:
           for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
    }

    private void Movement()
    {
        float randomX = Random.Range(-15f, 15f);
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);

        if (transform.position.y <= -15f)
        {
            transform.position = new Vector3(randomX, 9, 0);
        }
    }
}
