using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour 
{
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject musicOffButton;
    public GameObject musicOnButton;

    public GameObject gameOverText;
    public GameObject scoreText;
    public GameObject recordText;
    private Text scoretext;
    private Text recordtext;

    private float time;

	private void Awake()
	{
        scoretext = scoreText.GetComponent<Text>();
        recordtext = recordText.GetComponent<Text>();
	}

	private void Update()
	{
        if(GameManager.instance.gameOver)
        {
            gameOverText.SetActive(true);
        }
        if(GameManager.instance.restartGame)
        {
            gameOverText.SetActive(false);
        }

        scoretext.text = "Score: " + GameManager.instance.score;
        recordtext.text = "Record: " + GameManager.instance.record;
	}

	public void MusicOnPressed()
    {
        SoundManager.instance.StopPlay();
        musicOffButton.SetActive(true);
        musicOnButton.SetActive(false);
    }

    public void MusicOffPressed()
    {
        SoundManager.instance.Play();
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);
    }

    public void PausePressed()
    {
        if (GameManager.instance.gameOver) return;

        GameManager.instance.pauseGame = true;
        SoundManager.instance.musicSource.Stop();

        time = Time.timeScale;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void PlayPressed()
    {
        if (GameManager.instance.gameOver) return;
        GameManager.instance.pauseGame = false;
        SoundManager.instance.musicSource.Play();
        Time.timeScale = time;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

}
