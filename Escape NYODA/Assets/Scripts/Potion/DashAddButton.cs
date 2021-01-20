using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAddButton : MonoBehaviour
{
    private IgorDash igorDash;
    public float dashBoost = 10f;
    
    private void Start()
    {
        igorDash = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorDash>();
    }

    public void Use()
    {
        if (igorDash.currentDashTime > 0)
        {
            
            igorDash.currentDashTime += dashBoost;
            Destroy(gameObject);
        }

    }
}
