using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Player _player;
    private Animator _anim;
    private BoxCollider2D _col;
    private Animator _camAnim;

    [SerializeField]
    private GameObject _enemyLaser;

    private float _fireRate = 3;
    private float _canFire = -1f;

    [SerializeField]
    private AudioClip _enemyExplodeClip;

    private SpawnManager _spawnManager;

    [SerializeField]
    private GameObject _shields;

    private bool _randomBool;

    private void Start()
    {  
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is Null");
        }
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _anim = GetComponent<Animator>();
        _col = GetComponent<BoxCollider2D>();
        _camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        _randomBool = Random.value > 0.5f;
        _shields.SetActive(_randomBool);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {  
            //sets 10 pointsd for killing this enemy. 
            //Make switch statement to call which enemy was killed. <3 
            if(_shields.activeSelf == true)
            {
                _shields.SetActive(false);
                return;
            }
            else if (_shields.activeSelf == false)
            {
                _anim.SetBool("Hit", true);
                _player.ScoreKeeper(10);
                _col.enabled = false;
                // destroyed.Post(gameObject);
                AudioSource.PlayClipAtPoint(_enemyExplodeClip, new Vector3(0,0,-15));

                _spawnManager._enemiesDestroyed++;
                Destroy(this.gameObject, 2.5f);
            }
  
        }

        if (other.CompareTag("Missle"))
        {
            //sets 10 pointsd for killing this enemy. 
            //Make switch statement to call which enemy was killed. <3 
            if (_shields.activeSelf == true)
            {
                _shields.SetActive(false);
                return;
            }
            else if (_shields.activeSelf == false)
            {
                _anim.SetBool("Hit", true);
                _player.ScoreKeeper(10);
                _col.enabled = false;
                //destroyed.Post(gameObject);
                AudioSource.PlayClipAtPoint(_enemyExplodeClip, new Vector3(0, 0, -15));
                _spawnManager._enemiesDestroyed++;
                Destroy(this.gameObject, 2.5f);
            }

        }

        if (other.CompareTag("Player"))
        {
            _anim.SetBool("Hit", true);
            //destroyed.Post(gameObject);
            AudioSource.PlayClipAtPoint(_enemyExplodeClip, new Vector3(0, 0, -15));
            _camAnim.SetTrigger("Shake");
            _spawnManager._enemiesDestroyed++;
            Destroy(this.gameObject, 2.5f); 
            _player.Damage();
        }

        if(other.CompareTag("ShieldPowerUp"))
        {
            _shields.SetActive(true);
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
           GameObject _enemyLaserGo = Instantiate(_enemyLaser, transform.position, Quaternion.identity);
            Laser[] lasers = _enemyLaserGo.GetComponentsInChildren<Laser>();
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
