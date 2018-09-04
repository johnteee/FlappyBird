using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
    public float jumpForce;
    private bool isDead = false;

    new private Rigidbody2D rigidbody;
    private Animator animator;

    public AudioClip dieSound;

    public AudioClip hitSound;

    public AudioClip swooshingSound;
    public AudioClip wingSound;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        Debug.Log(Camera.main.orthographicSize);
    }
		
	void Update () 
    {
        if(!GameController.instance.pauseGame)
        {
            bool tap = false;
            if (Input.GetMouseButtonDown(0)) tap = true;

            if(GameController.instance.startGame == false)
            {
                rigidbody.isKinematic = false;
            }
            if(!isDead)
            {
                if (tap && CheckBounds())
                {
                    Jump();
                }
            } 
        }

	}

    private bool CheckBounds()
    {
        
        if(Camera.main.orthographicSize < transform.position.y + GetComponent<BoxCollider2D>().size.y)
        {
            return false;
        }

        return true;
    }

    private void Jump()
    {
        animator.SetTrigger("Flap");
        SoundManager.instance.PlaySingle(wingSound);
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(new Vector2(0, jumpForce));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        isDead = true;
        animator.SetTrigger("Die");
        GameController.instance.BirdDie();
        if(collision.gameObject.tag == "Columns")
        {
            SoundManager.instance.PlaySingle(hitSound);
        }
        else if(collision.gameObject.tag == "Ground")
        {
            SoundManager.instance.PlaySingle(dieSound);
        }

	}
}
