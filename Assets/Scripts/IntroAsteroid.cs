using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAsteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private GameObject _explosionPrefab;

    private SpawnManager _spawnManager;
    private Animator _camAnim;

    private void Start()
    {
        _camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _camAnim.SetTrigger("Shake");
            _spawnManager.StartSpawning();
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed) * Time.deltaTime);
    }
}
