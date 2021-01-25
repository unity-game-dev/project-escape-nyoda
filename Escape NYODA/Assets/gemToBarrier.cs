using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemToBarrier : MonoBehaviour
{
    public GameObject BarrierUI;
    public GameObject GemUI;
    public void openBarrier(){
        BarrierUI.SetActive(true);
        GemUI.SetActive(false);
    }
}
