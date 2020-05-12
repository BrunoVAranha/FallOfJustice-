using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slide;
    private int maxHealth;
    private int currentHealth;

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
        
    }

    public void takeDamage(int damage)
    {
        slide.value = currentHealth - damage;
        currentHealth = currentHealth - damage;

    }
}
