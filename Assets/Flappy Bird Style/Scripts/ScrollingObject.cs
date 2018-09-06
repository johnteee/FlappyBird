using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
    private Rigidbody2D rb2d;
    private float scrollingLength;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       // Debug.Log(GameManager.instance.scrollSpeed);
        rb2d.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);

        scrollingLength = GameManager.instance.groundHorizontalLength;

    }

    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
        if(GameManager.instance.restartGame)
        {
            rb2d.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);
        }
        if (transform.position.x + scrollingLength / 2 + 1f< Camera.main.transform.position.x - Camera.main.orthographicSize - 4f)
        {
            RepositionObject();
        }
    }

    private void RepositionObject()
    {
        Vector2 groundOffSet = new Vector2(scrollingLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
