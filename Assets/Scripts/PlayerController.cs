using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator animator;
   public Rigidbody2D rb2d;
   SpriteRenderer spriteRenderer;
   public PlayerAttack player;

   public bool isGrounded;
   float playerSpeedHorizontal = 3.5f;
   public bool canMove;
   private float nextJump;
   public bool isAlive;

   //AUDIO
   public AudioSource audio;
   public AudioClip hit;
   public AudioClip playerGotHit;

   [SerializeField]
   Transform groundCheck; 

 
    // Use this for initialization
    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        canMove = true;
        isAlive = true;
 
    }
 
    // Update is called once per frame
    private void FixedUpdate () {
        if(!canMove )
        {
            rb2d.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) 
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
       
            if(Input.GetKey("right"))
            {
                animator.SetFloat("Speed", playerSpeedHorizontal);
                rb2d.velocity = new Vector2(playerSpeedHorizontal, rb2d.velocity.y);
                spriteRenderer.flipX = false;
            }
            else if(Input.GetKey("left"))
            {
                rb2d.velocity = new Vector2(-playerSpeedHorizontal, rb2d.velocity.y);
                animator.SetFloat("Speed", Mathf.Abs(playerSpeedHorizontal));  
                spriteRenderer.flipX = true;
            }

            else
            {
                animator.SetFloat("Speed", 0);
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            
            }

           }
    
    public void getsHit()
    {
        animator.SetTrigger("Hit");
        audio.PlayOneShot(hit, 0.45f);
    }

    
}