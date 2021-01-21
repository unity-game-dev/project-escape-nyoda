using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleAddButton : MonoBehaviour
{
    private IgorInvincible igorInvincible;
    public float invincibleBoost = 5f;
    private Transform player;
    public GameObject invincibleEffect;
    private void Start()
    {
        igorInvincible = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorInvincible>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        if (igorInvincible.currentInvincibleTime > 0)
        {
            igorInvincible.currentInvincibleTime += invincibleBoost;
            Instantiate(invincibleEffect, player.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
