using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject controls;

    [SerializeField]
    private Image newGameButtonImage;
    [SerializeField]
    private Image controlButtonImage;

    [SerializeField]
    private Sprite[] sprites;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonHoverClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SpaceShooter");
    }

    public void Controls()
    {
        controls.SetActive(true);
    }
    public void BackButton()
    {
        controls.SetActive(false);
    }

    public void ButtonHover()
    {
        newGameButtonImage.sprite = sprites[1];
    }

    public void ButtonHoverExit()
    {
        newGameButtonImage.sprite = sprites[0];
    }

    public void ButtonHover2()
    {
        controlButtonImage.sprite = sprites[2];
    }

    public void ButtonHoverExit2()
    {
        controlButtonImage.sprite = sprites[3];
    }

    public void ButtonHoverSFX()
    {
        audioSource.pitch = Random.Range(0.85f, 1.0f);
        audioSource.clip = buttonHoverClip;
        audioSource.Play();
    }
}
