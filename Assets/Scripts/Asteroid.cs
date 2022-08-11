using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private GameObject explosionPrefab;

    private Animator cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            cam.SetTrigger("Shake");
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed)*Time.deltaTime);
    }
}
