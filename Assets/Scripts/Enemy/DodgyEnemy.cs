using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgyEnemy : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private GameObject _explodePrefab;

    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        Movement();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Missle"))
        {
            Debug.Log("Hit");
            Instantiate(_explodePrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if(other.CompareTag("Player"))
        {
            _player.Damage();
        }
    }


}
