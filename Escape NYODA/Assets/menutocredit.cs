using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menutocredit : MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject MainMenuUI;
    public void creditOpen(){
        controlsUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }
}
