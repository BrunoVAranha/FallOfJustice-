using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;
    float reachDistance;
    SpriteRenderer sprite;
    bool playerEventTrigger;

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
}
