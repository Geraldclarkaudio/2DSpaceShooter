using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemy : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int health;
    private bool hitPlayer = false;

    [SerializeField]
    private GameObject expoldePrefab;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        player = GameObject.Find("Player").GetComponent<Player>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            if(hitPlayer == false)
            {
                hitPlayer = true;
                player.Damage();
                health--;
            }
            else if(hitPlayer == true)
            {
                return;
            }
        }

       if(other.CompareTag("Laser"))
        {
            health--;
            StartCoroutine(HitVisual());
        }

       if(other.CompareTag("Missle"))
        {
            health = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hitPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -3f)
        {
            transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);
        }
        else if(transform.position.y >= -3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
        }

        if (health <= 0)
        {
            player.ScoreKeeper(50);
            Instantiate(expoldePrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator HitVisual()
    {
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
    }
}
