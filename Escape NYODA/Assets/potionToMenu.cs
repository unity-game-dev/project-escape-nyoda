using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionToMenu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject PotionUI;
    public void open(){
        MenuUI.SetActive(true);
        PotionUI.SetActive(false);
    }
}
