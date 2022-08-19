using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemy : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _health;
    private bool _hitPlayer = false;

    [SerializeField]
    private GameObject _expoldePrefab;

    private SpriteRenderer _renderer;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
        _player = GameObject.Find("Player").GetComponent<Player>();
        _renderer = GetComponent<SpriteRenderer>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            if(_hitPlayer == false)
            {
                _hitPlayer = true;
                _player.Damage();
                _health--;
            }
            else if(_hitPlayer == true)
            {
                return;
            }
        }

       if(other.CompareTag("Laser"))
        {
            _health--;
            StartCoroutine(HitVisual());
        }

       if(other.CompareTag("Missle"))
        {
            _health = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _hitPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -3f)
        {
            transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);
        }
        else if(transform.position.y >= -3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }

        if (_health <= 0)
        {
            _player.ScoreKeeper(50);
            Instantiate(_expoldePrefab, transform.position, Quaternion.identity);
            _spawnManager._enemiesDestroyed++;
            Destroy(this.gameObject);
        }
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
