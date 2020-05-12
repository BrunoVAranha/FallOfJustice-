using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    //public float timer;
    
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public StaminaBar staminaBar;

    public Animator attAnim;
    //public AudioSource source;
    public GameObject player;
    float atkCooldown = 1.2f;
    private float nextAtk;
    public bool canAtk;
    public bool isDamaged;
    public AudioClip attack;
    public AudioClip atkHit;
    // Update is called once per frame

    void Start()
    {
        canAtk = true;
    }

    void Update()
    {


            if(Input.GetKey("z") &&  
                player.GetComponent<PlayerController>().isGrounded && 
                Time.time > nextAtk &&
                !staminaBar.GetComponent<StaminaBar>().isTired &&
                canAtk) {

                player.GetComponent<PlayerController>().canMove = false;
                Invoke("playerCanMove", 0.6f);
                attAnim.SetTrigger("Attack");
                staminaBar.spendStamina(30);
                nextAtk = Time.time + atkCooldown;
                player.GetComponent<PlayerController>().audio.PlayOneShot(attack, 1.0f);
                if(!isDamaged )
                {
                Invoke("dmgEnemy", 0.3f);
                }
            }
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.
        DrawWireSphere(attackPos.position, attackRange);

    }

    void playerCanMove(){

            player.GetComponent<PlayerController>().canMove = true;
    }
    void dmgEnemy()
    {
    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(
                    attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                if(enemiesToDamage.Length > 0){
                Debug.Log("dmg");
                player.GetComponent<PlayerController>().audio.PlayOneShot(atkHit, 0.6f);
                }
    }
}
