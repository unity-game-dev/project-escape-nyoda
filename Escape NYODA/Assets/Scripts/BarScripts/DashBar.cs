using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    
    public Slider slider;

    public void setMaxDash(float dashTime)
    {
        slider.maxValue = dashTime;
        slider.value = dashTime;
    }
    public void setDash(float dashTime)
    {
        slider.value = dashTime;
    }
}
