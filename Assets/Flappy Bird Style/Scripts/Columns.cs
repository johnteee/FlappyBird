using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour 
{
    new private Rigidbody2D rigidbody;
	
	void Start () 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);
	}
		
	void Update () 
    {
        if(GameManager.instance.gameOver)
        {
            rigidbody.velocity = Vector2.zero;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.GetComponent<Bird>())
        {
            GameManager.instance.BirdScored();
        }
	}	
}
