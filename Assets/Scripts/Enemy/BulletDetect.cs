using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetect : MonoBehaviour
{
    private Animator _dodgyEnemy;

    private void Start()
    {
        //_dodgyEnemy = GameObject.Find("Dodgy Enemy").GetComponent<Animator>();
        _dodgyEnemy = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            _dodgyEnemy.SetTrigger("Dodge");
        }
    }
}
