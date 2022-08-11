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
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleShotPrefab;
    [SerializeField]
    private GameObject spreadShotPrefab;
    private float _canFire = -1f;
    [SerializeField]
    private float fireRate = 0.1f;
    private bool fired;
    private bool homingFired;
    [SerializeField]
    private GameObject homingMissle;

    [Header("Lives")]
    [SerializeField]
    public int _lives;
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private GameObject[] engines;

    [Header("PowerUps")]
    [SerializeField]
    private GameObject shields;
    public bool isTripleShotEnabled = false;
    public bool isShieldActive = false;
    public bool isSpeedACtive = false;
    public bool spreadShotActive = false;
    public GameObject Thruster;
    public bool gravityPull = false;
    [SerializeField]
    private GameObject gravityPullVisual;
    [SerializeField]
    private int score;
    [SerializeField]
    private int ammo;
    [SerializeField]
    private int homingAmmo;

    [SerializeField]
    private Slider slider;
    private bool thrusterActive = false;
    [SerializeField]
    private float thrusterUISpeed;

    private Animator camAnim;
    public float fuel;

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
        ammo = 15;
        homingAmmo = 5;
        _lives = 3;
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
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
        gravityPull = true;
        gravityPullVisual.SetActive(true);
    }

    private void GravityPull_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Let go");
        gravityPull = false;
        gravityPullVisual.SetActive(false);
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
            thrusterActive = false;
            Thruster.SetActive(false);

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
                Thruster.SetActive(true);
                _speed *= _speedMultiplier;
                thrusterActive = true;
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
            fired = true;

            if(fired ==true && Time.time > _canFire)
            {
                Fire();
            }
        }
    }

    private void HomingMissle_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            homingFired = true;

            if(homingFired == true && Time.time > _canFire)
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

        if(thrusterActive == true)
        {
            if(slider.value > 0)
            {
                slider.value -= thrusterUISpeed * Time.deltaTime;
            }
            else
            {
                Thruster.SetActive(false);
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
        if(ammo > 0)
        {
            _canFire = Time.time + fireRate;

            if (isTripleShotEnabled == true)
            {
                fired = false;
                Instantiate(tripleShotPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }
            else if(spreadShotActive == true)
            {
                fired = false;
                Instantiate(spreadShotPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }
            else
            {
                fired = false;
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                ammo--;
                _uiManager.UpdateAmmo(ammo);
            }
        }
    }

    private void FireHoming()
    {
        if(homingAmmo > 0)
        {
            _canFire = Time.time + fireRate;

            homingFired = false;
            Instantiate(homingMissle, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            homingAmmo--;

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
            //deactivateshields
            isShieldActive = false;
            shields.SetActive(false);
            return;
        }

        _lives--;
        camAnim.SetTrigger("Shake");
        if (_lives == 2)
        {
            engines[0].SetActive(true);
        }

        if(_lives == 1)
        {
            engines[1].SetActive(true);
        }

        _uiManager.UpdateLives(_lives);
        //You dead boi
        if(_lives <= 0)
        {
            _spawnManager.PlayerDied();
            GameManager.Instance.isGameOver = true;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void ScoreKeeper(int points)
    {
        score += points;
        _uiManager.UpdateScore(score);
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
        ammo = ammo + 5;
        _uiManager.UpdateAmmo(ammo);
    }

    private IEnumerator TripleShotCoolDown()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotEnabled = false;
    }

    public void SpeedActive()
    { 
        slider.value += fuel;
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
        shields.SetActive(true);
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
            engines[0].SetActive(false);
        }

        if(_lives == 1)
        {
            _lives++;
            _uiManager.UpdateLives(_lives);
            engines[1].SetActive(false);
        }

    }

    #endregion


}
