using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierToPotions : MonoBehaviour
{
    public GameObject potionUI;
    public GameObject barrierUI;
    public void openPotion(){
        potionUI.SetActive(true);
        barrierUI.SetActive(false);
    }
}
