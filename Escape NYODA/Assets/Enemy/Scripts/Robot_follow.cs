using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_follow : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1;
    public int maxHealth = 100;
    int currentHealth;

    private float nextFireTime;
    protected bool facingRight;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private Animator anim;

    public GameObject secAmmo;
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            AudioManager.instance.StopPlaying("Charge");
            anim.SetBool("Attack", false);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            AudioManager.instance.Play("Charge");
            anim.SetBool("Attack", true);
            nextFireTime = Time.time + fireRate;
        }
        if (Vector3.Distance(player.position, transform.position) < 20)
        {
            if (player.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
                Flip();
            if (player.position.x < transform.position.x && facingRight)
                Flip();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        
        anim.SetBool("die", true);
        AudioManager.instance.Play("MissileExplosion");
        Instantiate(secAmmo, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject, 1.2f);
        
        this.enabled = false;

    }
}
