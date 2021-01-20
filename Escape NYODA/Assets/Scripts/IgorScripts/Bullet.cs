using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //****//
    public int attackDamage = 50;
    //***//
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        //***//
        if(hitInfo.tag == "Robot")
        {
            Robot_Script enemy = hitInfo.GetComponent<Robot_Script>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
            
        }
        else if (hitInfo.tag == "Plasma")
        {
            Robot_follow enemy = hitInfo.GetComponent<Robot_follow>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }

        }
        //***//
        Destroy(gameObject);
    }
}
