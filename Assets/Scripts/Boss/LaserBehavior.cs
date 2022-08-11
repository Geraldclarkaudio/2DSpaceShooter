using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    private float speed = 7f;

    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.CompareTag("Player"))
        {
            player.Damage();
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
