using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehavior : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            player.Damage();
    }
}
