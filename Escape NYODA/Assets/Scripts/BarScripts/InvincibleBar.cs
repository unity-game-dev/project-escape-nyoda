using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvincibleBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxInvincible(float invincibleTime)
    {
        slider.maxValue = invincibleTime;
        slider.value = invincibleTime;
    }
    public void setInvincible(float invincibleTime)
    {
        slider.value = invincibleTime;
    }
}
