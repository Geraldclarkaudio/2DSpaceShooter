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
    private Sprite[] sprites;

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
}
