using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    //public float speed;
    float reachDistance;
    SpriteRenderer sprite;
    bool playerEventTrigger;
    public LayerMask whatIsPlayer;
    public HealthBar playerHB;
    public AudioClip hit;
    public GameObject player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim =  GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerEventTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("damage taken");
    }

    public void dmgPlayer(int unitDamage, Transform attackPos, float attackRange)
    {
    Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(
                    attackPos.position, attackRange, whatIsPlayer);
                for(int i = 0; i < playerToDamage.Length; i++) {
                playerHB.takeDamage(unitDamage);
                }
                if(playerToDamage.Length > 0){
                Debug.Log("playerDamaged");

                player.GetComponent<PlayerController>().getsHit(); // audio do player sendo atingido
                }
    }
}
