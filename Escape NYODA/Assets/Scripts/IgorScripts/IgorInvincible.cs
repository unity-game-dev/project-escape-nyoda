using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgorInvincible : MonoBehaviour
{
    public float maxInvincibleTime = 30f;
    public float currentInvincibleTime = 0f;
    public InvincibleBar invincibleBar;
    // Start is called before the first frame update
    void Start()
    {
        invincibleBar.setInvincible(currentInvincibleTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInvincibleTime > 0)
        {
            ReduceInvincible();
        }
    }

    void ReduceInvincible()
    {
        currentInvincibleTime -= Time.deltaTime;
        invincibleBar.setInvincible(currentInvincibleTime);
    }
}
