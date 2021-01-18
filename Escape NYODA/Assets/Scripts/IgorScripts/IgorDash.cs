using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgorDash : MonoBehaviour
{
    public float maxDashTime = 45f;
    public float currentDashTime = 0f;
    public DashBar dashBar;
    // Start is called before the first frame update
    void Start()
    {
        dashBar.setDash(currentDashTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDashTime > 0)
        {
            ReduceDash();
        }
    }

    void ReduceDash()
    {
        currentDashTime -= Time.deltaTime;
        dashBar.setDash(currentDashTime);
    }
    
}
