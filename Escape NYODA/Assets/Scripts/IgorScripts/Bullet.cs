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
    public GameObject guard;
    public int attackDamage = 50;
    //***//
    public GameObject bulletImpact;
    public GameObject bulletParticleImpact;
    private void Start()
    {
        rb.velocity = transform.right * speed;
        guard = GameObject.FindGameObjectWithTag("Guard");
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.tag);
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
            Guard_behaviour enemy = guard.GetComponent<Guard_behaviour>();
            if (enemy != null)
            {
                Debug.Log(enemy);
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
        if (hitInfo.name != "attack_collider" || hitInfo.name != "triggerArea" || hitInfo.name != "hit_box") 
        {
            Instantiate(bulletImpact, transform.position, transform.rotation);
            Instantiate(bulletParticleImpact, transform.position, transform.rotation);
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
