using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Transform _target;

    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private LayerMask _enemyLayer;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _angleChangeSpeed;

    void Update()
    {
        if (_target == null)
        {
            Debug.Log("No _target");
            transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime);

            if(transform.position.y >= 16)
            {
                Destroy(this.gameObject);
            }
        }

        else if (_target!= null) // somehow this code works. 
        {
            float distance = Vector3.Distance(transform.position, _target.position);
            Vector2 dir = (Vector2)_target.position - _rb.position;
            float rotAmount = Vector3.Cross(dir, transform.up).z;


            _rb.angularVelocity = -_angleChangeSpeed * rotAmount;
            _rb.velocity = transform.up * _speed;

            if (distance <= 1)
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
              //  Destroy(_explosion, 2.0f);
            }
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 11)
        {
            Debug.Log("Theres one!");
            _target = other.gameObject.transform;
        }
    }
}
