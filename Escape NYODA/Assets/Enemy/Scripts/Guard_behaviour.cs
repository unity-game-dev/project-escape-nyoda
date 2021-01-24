using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit; 
    public int maxHealth = 200;
    public int currentHealth;
    public GameObject bullet;
    public GameObject bulletParent;
    public float shootingRange;
    public float fireRate = 1;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private float nextFireTime;
    private Transform target;
    private Transform player;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion



    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Awake()
    {
        
        SelectTarget();
        
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time && !attackMode)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            Debug.Log("Bullet");
            nextFireTime = Time.time + fireRate;
        }
        if (!attackMode)
        {
            Move();
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("guard_attack1"))
        {
            SelectTarget();
        }
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            
            StopAttack();
        }

        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }
        Debug.Log(trig.name);
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if(distance > attackDistance)
        {
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            
            Attack();
        }

        if (cooling)
        {
            Cooldown();

            anim.SetBool("attack1", false);
            
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        //AudioManager.instance.Play("Guard_walk");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("guard_attack1"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {

        timer = intTimer;
        attackMode = true;
        
        //AudioManager.instance.StopPlaying("Guard_walk");
        anim.SetBool("canWalk", false);
        anim.SetBool("attack1", true);

    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        
        anim.SetBool("attack1", false);
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        
        
        if (currentHealth <= 0)
        {
            Die();
            FindObjectOfType<GameManager>().EndDemo();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    void Die()
    {
        AudioManager.instance.Play("power");
        anim.SetBool("die", true);
        Destroy(gameObject, 1.5f);
        this.enabled = false;

    }
}
