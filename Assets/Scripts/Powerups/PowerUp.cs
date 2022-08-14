using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Player _player;

    [SerializeField]
    private int _powerUpID; 

    [SerializeField]
    private AudioClip _powerUpCollected;

    void Start()
    {        
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is Null");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           
            switch(_powerUpID)
            {
                case 0:
                    _player.TripleShotActive();
                    //powerUpSwitch.SetValue(gameObject);
                    //_powerUpCollectedSound.Post(gameObject);
                    AudioSource.PlayClipAtPoint(_powerUpCollected, new Vector3(0, 0, -15));
                    break;
                case 1:
                    //powerUpSwitch.SetValue(gameObject);
                    //_powerUpCollectedSound.Post(gameObject);
                    AudioSource.PlayClipAtPoint(_powerUpCollected, new Vector3(0, 0, -15));

                    _player.SpeedActive();

                    break;
                case 2:
                    _player.ShieldActive();
                    //powerUpSwitch.SetValue(gameObject);
                    //_powerUpCollectedSound.Post(gameObject);
                    AudioSource.PlayClipAtPoint(_powerUpCollected, new Vector3(0, 0, -15));

                    break;
                case 3:
                    _player.AddHealth();
                    //powerUpSwitch.SetValue(gameObject);
                    //_powerUpCollectedSound.Post(gameObject);
                    AudioSource.PlayClipAtPoint(_powerUpCollected, new Vector3(0, 0, -15));

                    break;
                case 4:
                    _player.AmmoPowerUp();
                    //powerUpSwitch.SetValue(gameObject);
                    //_powerUpCollectedSound.Post(gameObject);
                    AudioSource.PlayClipAtPoint(_powerUpCollected, new Vector3(0, 0, -15));

                    break;
                case 5:
                    _player.SpreadShotActive();
                    //powerUpSwitch.SetValue(gameObject);
                    //_powerUpCollectedSound.Post(gameObject);
                    AudioSource.PlayClipAtPoint(_powerUpCollected, new Vector3(0, 0, -15));

                    break;
                case 6:
                    _player.Damage();
                    break;

            }
           
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_player._gravityPull == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
        else if(_player._gravityPull == false)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
      

        if(transform.position.y <= -7.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
