using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleAddButton : MonoBehaviour
{
    private IgorInvincible igorInvincible;
    public float invincibleBoost = 5f;
    private void Start()
    {
        igorInvincible = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorInvincible>();
    }

    public void Use()
    {
        if (igorInvincible.currentInvincibleTime > 0)
        {
            igorInvincible.currentInvincibleTime += invincibleBoost;
            Destroy(gameObject);
        }
    }
}
