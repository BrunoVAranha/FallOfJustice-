using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slide;
    private int maxHealth;
    private int currentHealth;
    public AudioSource audio;
    public AudioClip deathSong;
    public Animator endLevel;
    public GameObject player;
    public Animator playerAnim;
    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
      maxHealth = 100;
      currentHealth = maxHealth;
      slide.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      if(currentHealth <= 0){

        player.GetComponent<PlayerController>().isAlive = false;
        player.GetComponent<PlayerController>().canMove = false;
        playerAnim.Play("Player_death");
        camera.GetComponent<CameraFollow2>().audio.Stop();
        audio.PlayOneShot(deathSong, 0.01f);
        Invoke("deathFadeOut", 1.0f);
        Invoke("respawnPlayer", 3.0f);
      }
        
    }

    public void takeDamage(int damage)
    {
        slide.value = currentHealth - damage;
        currentHealth = currentHealth - damage;

    }

    public void respawnPlayer(){

        Application.LoadLevel("Demo");
    }

    public void deathFadeOut(){

        endLevel.Play("Fade_Out");
    }

}
