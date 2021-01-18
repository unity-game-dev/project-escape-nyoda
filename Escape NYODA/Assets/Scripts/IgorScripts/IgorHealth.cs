using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgorHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public HealthAddButton healthAddButton;
    public IgorInvincible igorInvincible;
    public int healthBoost = 30;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth>0 || currentHealth < maxHealth)
        {
            if (igorInvincible.currentInvincibleTime > 0)
            {
               
                TakeDamage(0);
                
            } else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    TakeDamage(10);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddHealth();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void AddHealth()
    {
        
            currentHealth += healthBoost;
            healthBar.SetHealth(currentHealth);
            //healthAddButton.isUseHealthItem = false;
    }
}
