using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toControls : MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject MainMenuUI;
    public void open(){
        controlsUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }
}
