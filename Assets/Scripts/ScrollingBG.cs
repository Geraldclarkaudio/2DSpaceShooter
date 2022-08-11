using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.05f;

    [SerializeField]
    private GameObject backgroundPrefab;

    [SerializeField]
    private Vector3 originalPos;

    [SerializeField]
    private bool hasSpawned = false;


    // Update is called once per frame
    [SerializeField]
    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= 23.7 && hasSpawned == false)
        {
            Instantiate(backgroundPrefab, originalPos, Quaternion.identity);
            hasSpawned = true;
        }

        if(transform.position.y <= -111)
        {
            Destroy(this.gameObject);
        }
    }
}
