using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loadingtoMenu : MonoBehaviour
{   //public string levelToLoad;
    //rivate float timer = 8f;
    //private Text timerSeconds;

    void Start () {

    StartCoroutine (loadSceneAfterDelay(8));

    }

    IEnumerator loadSceneAfterDelay(float waitbySecs){

        yield return new WaitForSeconds(waitbySecs);
        Application.LoadLevel (1);
    } 
}
    