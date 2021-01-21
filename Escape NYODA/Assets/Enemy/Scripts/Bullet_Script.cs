﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        //***//
        IgorInvincible enemyInvincible = hitInfo.GetComponent<IgorInvincible>();
        IgorHealth enemy = hitInfo.GetComponent<IgorHealth>();
        if (enemy != null)
        {
            if(enemyInvincible.currentInvincibleTime > 0)
            {
                enemy.TakeDamage(0);
            } else
            {
                enemy.TakeDamage(15);
            }
        }
        //***//
        Destroy(gameObject);
        
        
    }


}
