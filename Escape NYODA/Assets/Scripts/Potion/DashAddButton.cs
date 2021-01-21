using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAddButton : MonoBehaviour
{
    private IgorDash igorDash;
    public float dashBoost = 10f;
    private Transform player;
    public GameObject dashEffect;

    private void Start()
    {
        igorDash = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorDash>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        if (igorDash.currentDashTime > 0)
        {
            
            igorDash.currentDashTime += dashBoost;
            Instantiate(dashEffect, player.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
