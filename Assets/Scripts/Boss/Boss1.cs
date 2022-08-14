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
    private Transform[] _waypoints;

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private int i;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _beamPrefab;

    private Vector3 _leftFire;
    private Vector3 _rightFire;

    [SerializeField]
    private int _health = 150;
    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private Transform[] _explosionLocations;
    [SerializeField]
    private GameObject _exlodePrefab;
    [SerializeField]
    private GameObject _bigExplosion;
    [SerializeField]
    private bool __isDead;
    [SerializeField]
    private GameObject _youWinPanel;

    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _healthBar;

    // Start is called before the first frame update
    void Start()

    {
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _renderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0, 16, 0); //Spawn above screen bounds.
        _leftFire = new Vector3(-4, -4, 0);
        _rightFire = new Vector3(4, -4, 0);
        __isDead = false;
        _healthBar.SetActive(true);
        StartCoroutine(WaitToFire());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            if(__isDead == false)
            {
                Damage();
            }

            else if(__isDead == true)
            {
                return;
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_health >= 0.1f)
        {
            Movement();
        }
    }

    public void Movement()
    {
        _target = _waypoints[i];
        float distance = Vector3.Distance(transform.position, _target.position);
        _target.position = _waypoints[i].position;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (distance <= 0.5f)
        {
            if (_target.position == _waypoints[0].position)
            {
                i++;
            }

            if (_target.position == _waypoints[2].position)
            {
                i--;
            }

            if (_target.position == _waypoints[1].position)
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
            Instantiate(_laserPrefab, transform.position + _leftFire, Quaternion.identity);
        }
    }

    IEnumerator RightFireRoutine()
    {
        while (GameManager.Instance.isGameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            Instantiate(_laserPrefab, transform.position + _rightFire, Quaternion.identity);
        }
    }
    IEnumerator FireBeamRoutine()
    {
        while (GameManager.Instance.isGameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(10,15));
            _beamPrefab.SetActive(true);
            yield return new WaitForSeconds(5f);
            _beamPrefab.SetActive(false);        
        }
    }

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(7.0f);
        Fire();
    }

    public void Damage()
    {
        _health--;
        _slider.value = _slider.value - 0.006666667f;
        StartCoroutine(colorFlashHit());

        if (_health <= 0)
        {
            __isDead = true;
                _slider.value = 0;
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
        Instantiate(_exlodePrefab, _explosionLocations[0].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_exlodePrefab, _explosionLocations[1].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_exlodePrefab, _explosionLocations[2].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_exlodePrefab, _explosionLocations[3].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_exlodePrefab, _explosionLocations[0].position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(_exlodePrefab, _explosionLocations[1].position, Quaternion.identity);
    }

    IEnumerator BigExplosion()
    {
        _spawnManager.StopSpawning();
        yield return new WaitForSeconds(9f);

        Instantiate(_bigExplosion, transform.position, Quaternion.identity);
        _youWinPanel.SetActive(true);
        _healthBar.SetActive(false);
        GameManager.Instance.gameWon = true;
    }
}
