using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public GameObject scoreText;
    public GameObject recordText;

    public bool gameOver = false;
    public bool pauseGame = false;
    public bool startGame = false;
    public float scrollSpeed = -1f;
    public int score;
    public int record;

    public AudioClip pointSound;
    public float groundHorizontalLength;
    public Vector3 screenParametrs;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        groundHorizontalLength = GameObject.FindWithTag("Ground").GetComponent<BoxCollider2D>().size.x;
        screenParametrs = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

        record = PlayerPrefs.GetInt("record");
        ChangeTextRecord();
    }

    void Update()
    {
        CheckRecord();
        screenParametrs = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        bool tap = false;
        if (Input.GetMouseButtonDown(0)) tap = true;


        if (gameOver && tap)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SoundManager.instance.musicSource.Play();
        }
	}

    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        SoundManager.instance.musicSource.Stop();
    }

    public void BirdScored()
    {
        score++;
        CheckRecord();
        Time.timeScale += 0.05f;
        Text text = scoreText.GetComponent<Text>();
        text.text = "Score: " + score;
        SoundManager.instance.PlayPointSound(pointSound);
    }

    public void CheckRecord()
    {
        if(score > record)
        {
            PlayerPrefs.SetInt("record", score);
            PlayerPrefs.Save();
        }
        record = PlayerPrefs.GetInt("record");
    }

    public void ChangeTextRecord()
    {
        record = PlayerPrefs.GetInt("record");
        Text text = recordText.GetComponent<Text>();
        text.text = "Record: " + record;
    }

}
