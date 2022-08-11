using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is Null");
            }

            return _instance;
        }
    }

    private Player player;
    public bool isGameOver;
    public bool gameWon;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(WaitForControls());
    }

    private void QuitButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void Awake()
    {
        _instance = this;
    }

    private IEnumerator WaitForControls()
    {
        yield return new WaitForSeconds(1.0f);
        player._input.PlayerControls.QuitButton.performed += QuitButton_performed;
    }
}
