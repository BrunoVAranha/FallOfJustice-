using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    float reachDistance;
    public GameObject player;
    public GameObject ghost; 
    SpriteRenderer sprite;
    bool playerEventTrigger;
    public AudioSource audio;
    public AudioClip spawn;
    public AudioClip vanish;
    private DialogueHolder dHolder;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim =  GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerEventTrigger = true;
        dHolder = FindObjectOfType<DialogueHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
        reachDistance = Vector3.Distance(player.transform.position, ghost.transform.position);
         if(reachDistance < 5.0f && playerEventTrigger){
                   sprite.sortingOrder = 9;
                   audio.PlayOneShot(spawn, 1.0f); 
                   anim.SetTrigger("Appear");
                   anim.SetTrigger("EnterIdle");
                   playerEventTrigger = false;
         }

         if(dHolder.ghostVanish == true)
         {
             Debug.Log("destroyed");
            audio.PlayOneShot(vanish, 0.2f); 
            anim.SetTrigger("Vanish");
            Invoke("DestroyGhost", 0.6f);
         }
    }

    void DestroyGhost()
    {
        Destroy(gameObject);
    }
}
