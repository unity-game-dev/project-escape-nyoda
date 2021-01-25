using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1;
    public int maxHealth = 100;
    int currentHealth;
    int drop = 1;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private GameObject attack_collider;


    private float nextFireTime;
    protected bool facingRight;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private Animator anim;

    public GameObject priAmmo;
    void Start()
    {
        //GetComponent<BoxCollider2D>().enabled = true;
        //attack_collider.GetComponent<BoxCollider2D>().enabled = true;
        currentHealth = maxHealth;
        attack_collider = GameObject.FindGameObjectWithTag("attack_collider");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            AudioManager.instance.StopPlaying("Laser");
            anim.SetBool("Attack", false);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            //Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            AudioManager.instance.Play("Laser");
            anim.SetBool("Attack", true);
            Attack();
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
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D hitInfo in hitEnemies)
        {
            //Debug.Log(hitInfo.name);
            IgorHealth enemy = hitInfo.GetComponent<IgorHealth>();
            IgorInvincible enemyInvincible = hitInfo.GetComponent<IgorInvincible>();

            if (enemy != null)
            {
                if(enemyInvincible.currentInvincibleTime > 0)
                {
                    enemy.TakeDamage(0);
                } else
                {
                    enemy.TakeDamage(10);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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
        AudioManager.instance.Play("will");
        //GetComponent<BoxCollider2D>().enabled = false;
        //attack_collider.GetComponent<BoxCollider2D>().enabled=false;
        anim.SetBool("die", true);
        if(drop == 1)
        {
            Instantiate(priAmmo, gameObject.transform.position, Quaternion.identity);
            drop = 0;
        }
        
        Destroy(gameObject,1.2f);
        this.enabled = false;

    }

}
    
