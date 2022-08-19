using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidEnemy : MonoBehaviour
{
    public int health;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _rotSpeed;
    [SerializeField]
    private GameObject _explodePrefab;
    [SerializeField]
    private bool _atSentryPos = false;
    private SpriteRenderer _renderer;

    private Animator _anim;

    private SpawnManager _spawnManager;

    private void Awake()
    {
        health = 3;
    }
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(_explodePrefab, transform.position, Quaternion.identity);
            _spawnManager._enemiesDestroyed++;
            Destroy(this.gameObject);
        }


        if (_atSentryPos == true)
        {
            return;
        }
        else if(_atSentryPos == false)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);

        if(transform.position.y <= -14f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PatrolZone"))
        {
            _anim.SetBool("Rot", true);
            _atSentryPos = true;
            StartCoroutine(Patrol());
        }

        if(other.CompareTag("Laser"))
        {
            StartCoroutine(HitVisual());
            health--;
        }

        if(other.CompareTag("Missle"))
        {
            health = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PatrolZone"))
        {
            _anim.SetBool("Rot", false);
            _atSentryPos = false;
        }
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(12.0f);

        _atSentryPos = false;
    }

    IEnumerator HitVisual()
    {
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
    }
}
