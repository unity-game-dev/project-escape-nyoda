using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditTomenu: MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject MainMenuUI;
    public void creditclose(){
        controlsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
