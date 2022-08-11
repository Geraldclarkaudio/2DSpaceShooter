using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text ammoText;
    [SerializeField]
    private Sprite[] livesSprites;
    [SerializeField]
    private Image liveImage;

    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject restartText;
    [SerializeField]
    private TMP_Text waveText;
    [SerializeField]
    private GameObject waveTextPanel;
   

    private Player player; 
    // Start is called before the first frame update
    void Start()
    {
        liveImage.material.color = Color.white;
        scoreText.text = "Score: " + 0;
        ammoText.text = "15/15";
        gameOverText.SetActive(false);
        restartText.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateAmmo(int ammoAmount)
    {
        ammoText.text = ammoAmount.ToString() + "/15";
    }

    public void UpdateLives(int currentLives)
    {
        liveImage.sprite = livesSprites[currentLives];
        if(currentLives == 0)
        {
            liveImage.material.color = Color.red;
            StartCoroutine(TextFlicker());
            restartText.SetActive(true);
        }
    }

    public void UpdateWaveText(string text)
    {
        waveText.text = text;
        StartCoroutine(WAVETextFlicker());
    }

    private IEnumerator WAVETextFlicker()
    {
        waveTextPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        waveTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        waveTextPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        waveTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        waveTextPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        waveTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator TextFlicker()
    {
        while(player._lives == 0)
        {
            gameOverText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOverText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
