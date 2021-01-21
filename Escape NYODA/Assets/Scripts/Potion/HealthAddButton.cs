using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class HealthAddButton : MonoBehaviour
{
    private IgorHealth igorHealth;
    public int healthBoost = 30;
    public GameObject healthEffect;
    private Transform player;

    //public delegate void HPIncrease();
    //public static event HPIncrease hpIncrease;
    //public UnityEvent buttonClick;


    private void Start()
    {
        igorHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        if (igorHealth.currentHealth < igorHealth.maxHealth)
        {
             igorHealth.currentHealth += healthBoost;
             Destroy(gameObject);
             Instantiate(healthEffect, player.position, Quaternion.identity);
        }
        Debug.Log("HealthButtonisInUse");
        
    }
}
