using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetect : MonoBehaviour
{
    private Animator dodgyEnemy;

    private void Start()
    {
        //dodgyEnemy = GameObject.Find("Dodgy Enemy").GetComponent<Animator>();
        dodgyEnemy = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            dodgyEnemy.SetTrigger("Dodge");
        }
    }
}
