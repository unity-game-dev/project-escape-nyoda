using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAddButton : MonoBehaviour
{
    private IgorDash igorDash;
    public float dashBoost = 15f;
    public bool isUseHealthItem = false;
    private void Start()
    {
        igorDash = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorDash>();
    }

    public void Use()
    {
        if (igorDash.currentDashTime > 0)
        {
            isUseHealthItem = true;
            igorDash.currentDashTime += dashBoost;
            Destroy(gameObject);
        }

    }
}
