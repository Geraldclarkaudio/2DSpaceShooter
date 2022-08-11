using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidEnemyLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;


    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(0, 9);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PatrolZone"))
        {
            Debug.Log("not ignored");
            return;
        }
        if(other.CompareTag("PowerUp"))
        {
            StartCoroutine(laserActive());
            Destroy(other.gameObject, 0.5f);
        }
    }

    IEnumerator laserActive()
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        laser.SetActive(false);
    }
}
