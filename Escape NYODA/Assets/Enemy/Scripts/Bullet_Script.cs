using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        //***//
        if (hitInfo.name == "Igor")
        {
            IgorInvincible enemyInvincible = hitInfo.GetComponent<IgorInvincible>();
            IgorHealth enemy = hitInfo.GetComponent<IgorHealth>();
            if (enemy != null)
            {
                if (enemyInvincible.currentInvincibleTime > 0)
                {
                    enemy.TakeDamage(0);
                }
                else
                {
                    target.GetComponent<Animator>().SetTrigger("Hurt");
                    AudioManager.instance.Play("Hurt");
                    enemy.TakeDamage(15);
                }
            }
            //***//
            Destroy(gameObject);

        }
        else if (hitInfo.name == "Ground" || hitInfo.name == "Boundary")
        {
            Destroy(gameObject);
        }
    }


}
