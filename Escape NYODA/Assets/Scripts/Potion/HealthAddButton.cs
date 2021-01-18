using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthAddButton : MonoBehaviour
{
    private IgorHealth igorHealth;
    private HealthBar healthBar;
    public int healthBoost = 30;
    public bool isUseHealthItem = false;
    private void Start()
    {
        igorHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorHealth>();
        //healthBar = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<HealthBar>();
    }

    public void Use()
    {
        if (igorHealth.currentHealth < igorHealth.maxHealth)
        {
            isUseHealthItem = true;
            igorHealth.currentHealth += healthBoost;
            healthBar.SetHealth(igorHealth.currentHealth);
            Destroy(gameObject);
        }
        
    }

    /*private void Update()
    {
        if (isUseHealthItem)
        {
            igorHealth.currentHealth += healthBoost;
            isUseHealthItem = false;
        }
    }*/
}
