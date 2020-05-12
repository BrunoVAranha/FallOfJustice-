using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slide;
    private int maxStamina;
    private float currentStamina;
    public bool staminaBarIsEmpty;
    public GameObject player;
    public bool isTired;

    Coroutine staminaR = null;
    // Start is called before the first frame update
    void Start()
    {
      staminaBarIsEmpty = false;
      maxStamina = 100;
      currentStamina = maxStamina;
      slide.value = maxStamina; 
      staminaR = StartCoroutine(staminaRegen());
      isTired = false;  
    }

    // Update is called once per frame
    void Update()
    {
      if(currentStamina < 0)
      {
          currentStamina = 0;
          staminaBarIsEmpty = true;
          playerIsTired();
          Invoke("playerIsNotTired", 3.0f);
          slide.value = currentStamina;
          //player.GetComponent<PlayerAttack>().canAtk = false;
      }
      else
      {
          if( currentStamina > 100){
            currentStamina = 100;
          }
          staminaBarIsEmpty = false;
      }   
    }

    public void spendStamina(int cost)
    {
        slide.value = currentStamina - cost;
        currentStamina = currentStamina - cost;

    }
    void playerIsTired()
    {
      isTired = true;
    }

    void playerIsNotTired()
    {
      isTired = false;
    }



    IEnumerator staminaRegen(){
       while (player.GetComponent<PlayerAttack>().canAtk = true && currentStamina <= maxStamina ){
       currentStamina += 0.6f;
       slide.value = currentStamina; 
       yield return new WaitForSeconds(0.1f);
     }
   }

}
