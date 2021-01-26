using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public ArmRotation armRotation;
    public int attackDamage = 10;
    public Animator anim;
    public GameObject guard;



    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) && armRotation.isKnife == true)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                AudioManager.instance.Play("Knife");
            }
        }
        
    }

    private void Start()
    {
        guard = GameObject.FindGameObjectWithTag("Guard");
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D hitInfo in hitEnemies)
        {
            //Debug.Log(enemy.name);
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
                    Debug.Log(enemy);
                    enemy.TakeDamage(20);
                }

            }
        }
        
        
            anim.SetTrigger("Combat");
            CinemachineShake.Instance.ShakeCamera(3f, 0.1f);
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
