using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToGems : MonoBehaviour
{
    public GameObject GemUI;
    public GameObject controlUI;
    public void openGems(){
        GemUI.SetActive(true);
        controlUI.SetActive(false);
    }
}
