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
   



    // Update is called once per frame
    void Update()
    {
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

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log(enemy.name);
            if(enemy.tag == "Plasma")
            {
                enemy.GetComponent<Robot_follow>().TakeDamage(attackDamage);
            }
            if (enemy.tag == "Robot")
            {
                enemy.GetComponent<Robot_Script>().TakeDamage(attackDamage);
            }
            if (enemy.tag == "Guard")
            {
                enemy.GetComponent<Guard_behaviour>().TakeDamage(attackDamage);
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
