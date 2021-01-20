using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgorInvincible : MonoBehaviour
{
    public float maxInvincibleTime = 15f;
    public float currentInvincibleTime = 0f;
    public InvincibleBar invincibleBar;
    public Text invincibleText;
    // Start is called before the first frame update
    void Start()
    {
        //currentInvincibleTime = maxInvincibleTime;
        invincibleBar.setInvincible(currentInvincibleTime);
    }

    // Update is called once per frame
    void Update()
    {
        invincibleText.text = currentInvincibleTime.ToString();
        invincibleBar.setInvincible(float.Parse(invincibleText.text));
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
