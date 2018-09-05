using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
    private float jumpForce = 250f;
    private bool isDead = false;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private Vector3 startPosition;

    public AudioClip dieSound;
    public AudioClip hitSound;
    public AudioClip swooshingSound;
    public AudioClip wingSound;

    public Sprite idleSprite;
    //new private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();

        startPosition = transform.position;
    }
		
	void Update () 
    {
        if(!GameManager.instance.pauseGame)
        {
            bool tap = false;
            if (Input.GetMouseButtonDown(0)) tap = true;

            //Check if tab was on the button 
            if(!isDead && tap && CheckBounds())
            {
                Jump();
            }

            if(GameManager.instance.restartGame)
            {
                Reset();
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
        if(SoundManager.instance.canPlayMusic)
            SoundManager.instance.PlaySingle(wingSound);

        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(new Vector2(0, jumpForce));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        isDead = true;

        animator.SetTrigger("Die");
        GameManager.instance.BirdDie();

        if(collision.gameObject.tag == "Columns")
        {
            if (SoundManager.instance.canPlayMusic) SoundManager.instance.PlaySingle(hitSound);
        }
        else if(collision.gameObject.tag == "Ground")
        {
            if (SoundManager.instance.canPlayMusic) SoundManager.instance.PlaySingle(dieSound);
        }

	}

    public void Reset()
    {
        isDead = false;
        transform.position = startPosition;
        animator.SetTrigger("Idle");
    }

}
