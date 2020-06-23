using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    public GameObject player;
    public GameObject knight;
    SpriteRenderer spriteRenderer;
    bool playerEventTrigger;
    float reachDistance;
    bool knightIsAttacking;
    private PlayerController playerControl;
    public Transform attackPos;
    public float attackRange;
    public int unitDamage;

    float knightSpeedHorizontal = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerControl = FindObjectOfType<PlayerController>();
        playerEventTrigger = true;
        knightIsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        reachDistance = Vector3.Distance(player.transform.position, knight.transform.position);
        if(reachDistance <  10.0f && playerEventTrigger 
           ){
            if(!knightIsAttacking){
            animator.SetFloat("Speed", knightSpeedHorizontal);
            rb2d.velocity = new Vector2(-knightSpeedHorizontal, rb2d.velocity.y);
            }

            if(reachDistance < 3.0f && playerEventTrigger
                 && player.GetComponent<PlayerController>().isAlive){
                   knightIsAttacking = true; 
                   animator.SetFloat("Speed", 0);
                   knightAttack();
                   playerEventTrigger = false;
                   Invoke("knightNotAttacking", 4.0f);
                   Invoke("changePlayerEventTrigger", 2.0f);
            }
        }
    } 

    public void knightNotAttacking(){
        knightIsAttacking = false;
    }

    public void changePlayerEventTrigger(){
        playerEventTrigger = true;
    }

    public void knightAttack(){
        animator.SetTrigger("Attack");
        Invoke("damagePlayer", 0.8f);
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.
        DrawWireSphere(attackPos.position, attackRange);

    }
    void damagePlayer(){
    knight.GetComponent<Enemy>().dmgPlayer(unitDamage, attackPos, attackRange);
    }
}
