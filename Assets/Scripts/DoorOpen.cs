using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    public Animator doorAnim;
    public Animator endLevel;
    public AudioSource audio;
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D()
    {
        if(Input.GetKey("e"))
        {
            audio.Play();
            doorAnim.Play("Door_Open");
            endLevel.Play("Fade_Out");
            Invoke("EndLevel", 3.6f);
        }
    }

    void EndLevel(){
        Application.LoadLevel("Castle1");
    }
}
