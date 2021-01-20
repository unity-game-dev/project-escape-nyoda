using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgorDash : MonoBehaviour
{
    public float maxDashTime = 30f;
    public float currentDashTime = 0f;
    public Text dashText;
    public DashBar dashBar;

    // Start is called before the first frame update
    void Start()
    {
        dashBar.setDash(currentDashTime);
    }

    // Update is called once per frame
    void Update()
    {
        dashText.text = currentDashTime.ToString();
        dashBar.setDash(float.Parse(dashText.text));
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
