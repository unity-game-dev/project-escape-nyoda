using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeControls : MonoBehaviour
{
    public GameObject controlsUI;
    public GameObject MainMenuUI;
    public void close(){
        controlsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
