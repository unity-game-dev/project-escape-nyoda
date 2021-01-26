using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public GameObject redObstacle;
    public int attackDamage = 100;
    public GameObject guard;
    public GameObject missileImpact;
    public GameObject missileParticleImpact;
    private void Start()
    {
        guard = GameObject.FindGameObjectWithTag("Guard");
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
            Guard_behaviour enemy = guard.GetComponent<Guard_behaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage(50);
            }

        }
        if (hitInfo.tag == "redObstacle")
        {
            redObstacle = GameObject.FindGameObjectWithTag("redObstacle");
            Destroy(redObstacle);
            Destroy(gameObject);
        }
        if (hitInfo.name != "attack_collider" || hitInfo.name != "triggerArea" || hitInfo.name != "hit_box" || hitInfo.name != "Guard_Bullet" || hitInfo.name != "BossBG")
        {
            Instantiate(missileImpact, transform.position, transform.rotation);
            Instantiate(missileParticleImpact, transform.position, transform.rotation);
            Destroy(gameObject);
            AudioManager.instance.Play("MissileExplosion");
            CinemachineShake.Instance.ShakeCamera(20f, 0.2f);
        }
        
    }
}
