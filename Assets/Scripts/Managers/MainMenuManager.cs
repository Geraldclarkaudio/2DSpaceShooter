using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _controls;

    [SerializeField]
    private Image _newGameButtonImage;
    [SerializeField]
    private Image controlButtonImage;

    [SerializeField]
    private Sprite[] _sprites;

    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _buttonHoverClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SpaceShooter");
    }

    public void Controls()
    {
        _controls.SetActive(true);
    }
    public void BackButton()
    {
        _controls.SetActive(false);
    }

    public void ButtonHover()
    {
        _newGameButtonImage.sprite = _sprites[1];
    }

    public void ButtonHoverExit()
    {
        _newGameButtonImage.sprite = _sprites[0];
    }

    public void ButtonHover2()
    {
        controlButtonImage.sprite = _sprites[2];
    }

    public void ButtonHoverExit2()
    {
        controlButtonImage.sprite = _sprites[3];
    }

    public void ButtonHoverSFX()
    {
        _audioSource.pitch = Random.Range(0.85f, 1.0f);
        _audioSource.clip = _buttonHoverClip;
        _audioSource.Play();
    }
}
