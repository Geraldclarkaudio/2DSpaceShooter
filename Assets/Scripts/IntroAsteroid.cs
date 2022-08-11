using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAsteroid : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private GameObject explosionPrefab;

    private SpawnManager _spawnManager;
    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            camAnim.SetTrigger("Shake");
            _spawnManager.StartSpawning();
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }
}
