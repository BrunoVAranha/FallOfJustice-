using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private DialogueManager dMan;
    public string dialogue;
    public int contador;
    public bool isItGhost;
    public bool ghostVanish;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        dMan = FindObjectOfType<DialogueManager>();
        ghostVanish = false; 
    }

    // Update is called once per frame
    void Update()
    {
         if(dMan.dialogActive && Input.GetKey("x"))
        {
            dMan.dBox.SetActive(false);
            dMan.dialogActive = false;
            if (isItGhost == true)
            {
                ghostVanish = true;
            }
            player.GetComponent<PlayerController>().canMove = true;
            Invoke("playerCanAtk", 0.5f);
        }
    }

    void OnTriggerStay2D()
    {
        if(Input.GetKey("e"))
        {
            dMan.ShowBox(dialogue);
            contador = contador + 1;
            player.GetComponent<PlayerController>().canMove = false;
            player.GetComponent<PlayerAttack>().canAtk = false;
 
        }
    }

    void playerCanAtk(){
            player.GetComponent<PlayerAttack>().canAtk = true;
     }
}
