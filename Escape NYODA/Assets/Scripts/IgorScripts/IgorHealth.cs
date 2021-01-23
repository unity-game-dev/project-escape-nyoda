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
    public Animator anim;
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
                
            } 
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(100);
        }
    }

    //****  CHANGED TAKEDAMAGE TO PUBLIC ***///
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            igorDead();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void igorDead()
    {
        anim.SetBool("IsDead", true);
        Destroy(gameObject, 1.2f);
        //this.enabled = false;
    }
}
