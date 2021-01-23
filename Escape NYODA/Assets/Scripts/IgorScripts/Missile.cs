using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public GameObject redObstacle;
    public int attackDamage = 100;
    public GameObject missileImpact;
    public GameObject missileParticleImpact;
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Robot")
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
        if (hitInfo.tag == "redObstacle")
        {
            redObstacle = GameObject.FindGameObjectWithTag("redObstacle");
            Destroy(redObstacle);
            Destroy(gameObject);
        }
        Instantiate(missileImpact, transform.position, transform.rotation);
        Instantiate(missileParticleImpact, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioManager.instance.Play("MissileExplosion");
        CinemachineShake.Instance.ShakeCamera(10f, 0.2f);
    }
}
