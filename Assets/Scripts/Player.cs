using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private SpawnManager _spawnManager;
    private UIManager _uiManager; 

    public GameInput _input;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _speedMultiplier;
  

    //Laser Stuff
    [Header("Laser Stuff")]
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _spreadShotPrefab;
    private float _canFire = -1f;
    [SerializeField]
    private float _fireRate = 0.1f;
    private bool _fired;
    private bool _homingFired;
    [SerializeField]
    private GameObject _homingMissle;

    [Header("Lives")]
    [SerializeField]
    public int _lives;
    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject[] _engines;

    [Header("PowerUps")]
    [SerializeField]
    private GameObject _shields;
    public bool isTripleShotEnabled = false;
    public bool isShieldActive = false;
    public bool isSpeedACtive = false;
    public bool spreadShotActive = false;
    [SerializeField]
    private GameObject _thruster;
    public bool _gravityPull = false;
    [SerializeField]
    private GameObject _gravityPullVisual;
    [SerializeField]
    private int _score;
    [SerializeField]
    private int _ammo;
    [SerializeField]
    private int _homingAmmo;

    [SerializeField]
    private Slider slider; // TODO: put in UIManager
    private bool _thrusterActive = false;
    [SerializeField]
    private float _thrusterUISpeed;

    private Animator _camAnim;
    [SerializeField]
    private float _fuel;

    [Header("DialogInput")]
    public bool dialogIsPlaying;
    public bool dialogContinuePressed = false;

    private void Awake()
    {
        _input = new GameInput();
       
        _input.PlayerControls.Fire.performed += Fire_performed;
        _input.PlayerControls.Restart.performed += Restart_performed;
        _input.PlayerControls.Thruster.performed += Thruster_performed;
        _input.PlayerControls.Thruster.canceled += Thruster_canceled;
        _input.PlayerControls.ContinueDialog.performed += ContinueDialog_performed;
        _input.PlayerControls.GravityPull.performed += GravityPull_performed;
        _input.PlayerControls.GravityPull.canceled += GravityPull_canceled;
        _input.PlayerControls.HomingMissle.performed += HomingMissle_performed;
        _input.PlayerControls.Enable();
    }



    void Start()
    {
        slider.value = 1;
        _ammo = 15;
        _homingAmmo = 5;
        _lives = 3;
        _camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();


        if (_uiManager == null)
        {
            Debug.LogError("UI MAnager is null");
        }

        if(_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is null");
        }    
    }

    private void GravityPull_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("hOLDING");
        _gravityPull = true;
        _gravityPullVisual.SetActive(true);
    }

    private void GravityPull_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Let go");
        _gravityPull = false;
        _gravityPullVisual.SetActive(false);
    }



    private void ContinueDialog_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (dialogIsPlaying == true)
            {
                dialogContinuePressed = true;
                Debug.Log("dialoggg");
            }
        }
    }

    public bool GetDialogContinuePressed()
    {
        bool result = dialogContinuePressed;
        dialogContinuePressed = false;
        return result;
    }

    private void Thruster_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(_spawnManager.playerDied == false)
        {
            _thrusterActive = false;
            _thruster.SetActive(false);

            if (slider.value > 0)
            {

                _speed /= _speedMultiplier;

            }

            if (slider.value == 0)
            {
                _speed = 10;
            }
        }
    }

    private void Thruster_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(_spawnManager.playerDied == false)
        {
            if (slider.value > 0)
            {
                _thruster.SetActive(true);
                _speed *= _speedMultiplier;
                _thrusterActive = true;
            }

            return;
        }
    }

    private void Restart_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(GameManager.Instance.isGameOver == true)
        {
            _input.PlayerControls.Disable();
            RestartGame();
        }
        else if(GameManager.Instance.gameWon == true)
        {
            _input.PlayerControls.Disable();
            ReturnToTitle();
        }
        else
        {
            return;
        }
        
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _fired = true;

            if(_fired ==true && Time.time > _canFire)
            {
                Fire();
            }
        }
    }

    private void HomingMissle_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _homingFired = true;

            if(_homingFired == true && Time.time > _canFire)
            {
                FireHoming();
            }
        }
    }



    void Update()
    {
        if(dialogIsPlaying == true) //prevents movement when dialog is playing
        {
            return;
        }
            
        Movement();

        if(_thrusterActive == true)
        {
            if(slider.value > 0)
            {
                slider.value -= _thrusterUISpeed * Time.deltaTime;
            }
            else
            {
                _thruster.SetActive(false);
            }
        }
        else 
        { 
            slider.value = slider.value;
        }

        if(slider.value == 0)
        {
            _speed = 10;
        }
    }

    private void Movement()
    {
        //poll or check input readings 
        var move = _input.PlayerControls.Move.ReadValue<Vector2>();

        transform.Translate(move * _speed * Time.deltaTime);

        //set bounds: X Axis
        if(transform.position.x <= -16f)
        {
            transform.position = new Vector3(15.9f, transform.position.y, transform.position.z);
        }

        else if(transform.position.x >= 16f)
        {
            transform.position = new Vector3(-15.9f, transform.position.y, transform.position.z);
        }

        //Set Bounds: Y Axis
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -6.5f, 0));
    }

    private void Fire()
    {
        if(_ammo > 0)
        {
            _canFire = Time.time + _fireRate;

            if (isTripleShotEnabled == true)
            {
                _fired = false;
                Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }
            else if(spreadShotActive == true)
            {
                _fired = false;
                Instantiate(_spreadShotPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }
            else
            {
                _fired = false;
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                _ammo--;
                _uiManager.UpdateAmmo(_ammo);
            }
        }
    }

    private void FireHoming()
    {
        if(_homingAmmo > 0)
        {
            _canFire = Time.time + _fireRate;

            _homingFired = false;
            Instantiate(_homingMissle, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            _homingAmmo--;

        }
    }

    public void Damage()
    {
        if(GameManager.Instance.gameWon == true || dialogIsPlaying == true)
        {
            return;
        }

        if(isShieldActive == true)
        {
            //deactivate_shields
            isShieldActive = false;
            _shields.SetActive(false);
            return;
        }

        _lives--;
        _camAnim.SetTrigger("Shake");
        if (_lives == 2)
        {
            _engines[0].SetActive(true);
        }

        if(_lives == 1)
        {
            _engines[1].SetActive(true);
        }

        _uiManager.UpdateLives(_lives);
        //You dead boi
        if(_lives <= 0)
        {
            _spawnManager.PlayerDied();
            GameManager.Instance.isGameOver = true;
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void ScoreKeeper(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SpaceShooter");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }


    #region POWERUPS
    public void TripleShotActive()
    {
        isTripleShotEnabled = true;
        StartCoroutine(TripleShotCoolDown());
    }

    public void SpreadShotActive()
    {
        spreadShotActive = true;
        StartCoroutine(SpreadShotCoolDown());
    }

    private IEnumerator SpreadShotCoolDown()
    {
        yield return new WaitForSeconds(5.0f);
        spreadShotActive = false;
    }

    public void AmmoPowerUp()
    {
        _ammo = _ammo + 5;
        _uiManager.UpdateAmmo(_ammo);
    }

    private IEnumerator TripleShotCoolDown()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotEnabled = false;
    }

    public void SpeedActive()
    { 
        slider.value += _fuel;
    }

    private IEnumerator SpeedCoolDown()
    {
        yield return new WaitForSeconds(5f);
        isSpeedACtive = false;
        _speed /= _speedMultiplier;
    }

    public void ShieldActive()
    {
        isShieldActive = true;
        _shields.SetActive(true);
    }

    public void AddHealth()
    {

        if (_lives == 3)
        {
            return;
        }
        if(_lives == 2)
        {
            _lives++;
            _uiManager.UpdateLives(_lives);
            _engines[0].SetActive(false);
        }

        if(_lives == 1)
        {
            _lives++;
            _uiManager.UpdateLives(_lives);
            _engines[1].SetActive(false);
        }

    }

    #endregion


}
