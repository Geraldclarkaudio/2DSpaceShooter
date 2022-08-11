using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Player player;

    //PowerUpIDs
    //0 = triple
    //1 = Speed
    //2 = Shield
    [SerializeField]
    private int powerUpID; 

    [SerializeField]
    private AK.Wwise.Event powerUpCollectedSound;
    [SerializeField]
    private AK.Wwise.Switch powerUpSwitch;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if(player == null)
        {
            Debug.LogError("Player is Null");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           
            switch(powerUpID)
            {
                case 0:
                    player.TripleShotActive();
                    powerUpSwitch.SetValue(gameObject);
                    powerUpCollectedSound.Post(gameObject);
                    break;
                case 1:
                    powerUpSwitch.SetValue(gameObject);
                    powerUpCollectedSound.Post(gameObject);
                    player.SpeedActive();

                    break;
                case 2:
                    player.ShieldActive();
                    powerUpSwitch.SetValue(gameObject);
                    powerUpCollectedSound.Post(gameObject);
                    break;
                case 3:
                    player.AddHealth();
                    powerUpSwitch.SetValue(gameObject);
                    powerUpCollectedSound.Post(gameObject);
                    break;
                case 4:
                    player.AmmoPowerUp();
                    powerUpSwitch.SetValue(gameObject);
                    powerUpCollectedSound.Post(gameObject);
                    break;
                case 5:
                    player.SpreadShotActive();
                    powerUpSwitch.SetValue(gameObject);
                    powerUpCollectedSound.Post(gameObject);
                    break;
                case 6:
                    player.Damage();
                    break;

            }
           
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gravityPull == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
        }
        else if(player.gravityPull == false)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
      

        if(transform.position.y <= -7.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
