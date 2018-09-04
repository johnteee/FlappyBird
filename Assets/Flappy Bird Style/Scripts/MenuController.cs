using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour 
{
    
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject musicOffButton;
    public GameObject musicOnButton;

    private float time;

	public void MusicOnPressed()
    {
        SoundManager.instance.musicSource.Stop();
        musicOffButton.SetActive(true);
        musicOnButton.SetActive(false);
    }

    public void MusicOffPressed()
    {
        SoundManager.instance.musicSource.Play();
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);
    }

    public void PausePressed()
    {
        if (GameController.instance.gameOver) return;
        GameController.instance.pauseGame = true;
        SoundManager.instance.musicSource.Stop();
        time = Time.timeScale;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void PlayPressed()
    {
        if (GameController.instance.gameOver) return;
        GameController.instance.pauseGame = false;
        SoundManager.instance.musicSource.Play();
        Time.timeScale = time;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

}
