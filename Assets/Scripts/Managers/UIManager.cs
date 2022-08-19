using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _ammoText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _liveImage;

    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _restartText;
    [SerializeField]
    private TMP_Text _waveText;
    [SerializeField]
    private GameObject _waveTextPanel;

    [SerializeField]
    public Slider sliderThrustAmount;


    private Player player; 
    // Start is called before the first frame update
    void Start()
    {
        _liveImage.material.color = Color.white;
        _scoreText.text = "Score: " + 0;
        _ammoText.text = "15/15";
        _gameOverText.SetActive(false);
        _restartText.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
        sliderThrustAmount.value = 1;
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateAmmo(int ammoAmount)
    {
        _ammoText.text = ammoAmount.ToString() + "/15";
    }

    public void UpdateLives(int currentLives)
    {
        _liveImage.sprite = _livesSprites[currentLives];
        if(currentLives == 0)
        {
            _liveImage.material.color = Color.red;
            StartCoroutine(TextFlicker());
            _restartText.SetActive(true);
        }
    }

    public void UpdateWaveText(string text)
    {
        _waveText.text = text;
        StartCoroutine(WAVETextFlicker());
    }

    private IEnumerator WAVETextFlicker()
    {
        _waveTextPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _waveTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _waveTextPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _waveTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _waveTextPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _waveTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator TextFlicker()
    {
        while(player._lives == 0)
        {
            _gameOverText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
