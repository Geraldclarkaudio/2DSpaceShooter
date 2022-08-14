using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private GameObject _explosionPrefab;

    private Animator _cam;

    private void Start()
    {
        _cam = GameObject.Find("Main Camera").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _cam.SetTrigger("Shake");
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed)*Time.deltaTime);
    }
}
