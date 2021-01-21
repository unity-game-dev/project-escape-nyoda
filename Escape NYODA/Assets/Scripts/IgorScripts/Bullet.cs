using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject orangeObstacle;
    public bool isDestroyed = false;
    //****//
    public int attackDamage = 50;
    //***//
    public GameObject bulletImpact;
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
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
        else if (hitInfo.tag == "Guard")
        {
            Guard_behaviour enemy = hitInfo.GetComponent<Guard_behaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }

        }
        //***//
        if (hitInfo.tag == "orangeObstacle")
        {
            orangeObstacle = GameObject.FindGameObjectWithTag("orangeObstacle");
            Destroy(orangeObstacle);
        }
        Debug.Log(hitInfo.name);
        Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(gameObject);
        isDestroyed = true;
    }
}
