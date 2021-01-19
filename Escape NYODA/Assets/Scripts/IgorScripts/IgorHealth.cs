using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class IgorHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public HealthAddButton healthAddButton;
    public IgorInvincible igorInvincible;
    public int healthBoost = 30;
    //public Button button;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.ToString();
        healthBar.SetHealth(int.Parse(healthText.text));
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
    }
    /*void OnEnable()
    {
        HealthAddButton .hpIncrease += UsedIsClicked;
    }
    void OnDisable()
    {
        HealthAddButton .hpIncrease -= UsedIsClicked;
    }

    void UsedIsClicked()
    {
        healthBar.SetHealth(currentHealth);
    }*/
}
