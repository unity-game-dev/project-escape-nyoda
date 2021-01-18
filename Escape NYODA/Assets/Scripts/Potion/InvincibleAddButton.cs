using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleAddButton : MonoBehaviour
{
    private IgorInvincible igorInvincible;
    public float invincibleBoost = 5f;
    public bool isUseHealthItem = false;
    private void Start()
    {
        igorInvincible = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorInvincible>();
    }

    public void Use()
    {
        if (igorInvincible.currentInvincibleTime > 0)
        {
            isUseHealthItem = true;
            igorInvincible.currentInvincibleTime += invincibleBoost;
            Destroy(gameObject);
        }
    }
}
