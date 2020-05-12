using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skull : MonoBehaviour
{
    public GameObject skull;
    public GameObject player;
    private PlayerController playerControl;
    public Rigidbody2D rb2d;
    public HealthBar hB;
    public AudioSource audio;
    public AudioClip fogo;
    public AudioClip risada;

    bool playerEventTrigger;
    float reachDistance;

    // Start is called before the first frame update
    void Start()
    {
        playerEventTrigger = true;
        playerControl = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        reachDistance = Vector3.Distance(player.transform.position, skull.transform.position);
         if(reachDistance < 15.0f && playerEventTrigger){   
                
             rb2d.velocity = new Vector2(-8.0f, rb2d.velocity.y);
             audio.PlayOneShot(fogo, 0.1f);
             playerEventTrigger = false;
         }
    }

    void OnTriggerEnter2D()
    {
        playerControl.getsHit();
        hB.takeDamage(20);
        audio.PlayOneShot(risada, 0.4f);
        player.GetComponent<PlayerAttack>().isDamaged = true;
        Invoke("notDamaged", 0.5f);
    }

    void notDamaged()
    {
        player.GetComponent<PlayerAttack>().isDamaged = false;
    }
}
