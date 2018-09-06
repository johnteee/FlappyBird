using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver = false;
    public bool pauseGame = false;
    public bool startGame = false;
    public bool restartGame = false;
    public float scrollSpeed = -3f;
    public int score = 0;
    public int record;

    public AudioClip pointSound;
    public float groundHorizontalLength;
    public Vector3 screenParametrs;

    public Bird bird;

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
        if (restartGame) restartGame = false;
        CheckRecord();
        screenParametrs = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        bool tap = false;
        if (Input.GetMouseButtonDown(0)) tap = true;


        if (gameOver && tap)
        {
            restartGame = true;
            Restart();
            if (SoundManager.instance.canPlayMusic) SoundManager.instance.musicSource.Play();
        }
	}

    private void Restart()
    {
        Time.timeScale = 1f;
        score = 0;
        gameOver = false;
    }

    public void BirdDie()
    {
        gameOver = true;
        if (SoundManager.instance.canPlayMusic) SoundManager.instance.musicSource.Stop();
    }

    public void BirdScored()
    {
        score++;
        CheckRecord();
        scrollSpeed -= 0.05f;
        //Time.timeScale += 0.05f;
        if(SoundManager.instance.canPlayMusic)
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
    }

}
