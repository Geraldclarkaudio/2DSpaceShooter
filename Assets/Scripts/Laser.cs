using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    public bool isEnemyLaser = false;

    private Player player;

    [SerializeField]
    private AK.Wwise.Event playerLaser;

    [SerializeField]
    private AK.Wwise.Event enemyLaser;

   

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
                
        if (isEnemyLaser == false)
        {
            playerLaser.Post(gameObject);
        }
        else if(isEnemyLaser == true)
        {
            enemyLaser.Post(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
        }

        if(other.CompareTag("Player") && isEnemyLaser == true)
        {
            player.Damage();
        }

        if(other.CompareTag("Enemy") && isEnemyLaser == true)
        {
            Debug.Log("DO Nothing");
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (isEnemyLaser == false)
        {
            MoveUp();
            
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        
        transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime);

        if (transform.position.y >= 11f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);

        if (transform.position.y <= -11f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        isEnemyLaser = true;
        this.tag = "EnemyLaser";
    }
}
