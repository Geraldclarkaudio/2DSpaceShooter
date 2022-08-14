using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    private float _speed = 7f;

    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.CompareTag("Player"))
        {
            _player.Damage();
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
