using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthAddButton : MonoBehaviour
{
    private IgorHealth igorHealth;
    public int healthBoost = 30;
    public delegate void HPIncrease();
    public static event HPIncrease hpIncrease;

    private void Start()
    {
        igorHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorHealth>();
    }

    public void Use()
    {
        if (igorHealth.currentHealth < igorHealth.maxHealth)
        {
            igorHealth.currentHealth += healthBoost;
            Destroy(gameObject);
            hpIncrease();
        }
    }

    
}
