using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
    private Rigidbody2D rb2d;
    private float groundLength;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
        groundLength = GameController.instance.groundHorizontalLength;
    }

    void Update()
    {
        // If the game is over, stop scrolling.
        if (GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
        if (transform.position.x + groundLength / 2 + 1f< Camera.main.transform.position.x - Camera.main.orthographicSize - 4f)
        {
            RepositionObject();
        }
    }


    private void RepositionObject()
    {
        Vector2 groundOffSet = new Vector2(groundLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
