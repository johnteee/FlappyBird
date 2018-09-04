using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour 
{
    new private Rigidbody2D rigidbody;
	
	void Start () 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
	}
		
	void Update () 
    {
        if(GameController.instance.gameOver)
        {
            rigidbody.velocity = Vector2.zero;
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.GetComponent<Bird>())
        {
            GameController.instance.BirdScored();
        }
	}	
}
