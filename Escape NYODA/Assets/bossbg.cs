using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbg : MonoBehaviour
{
    int play = 1;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player" && play==1)
        {
            play = 0;
            AudioManager.instance.StopPlaying("BgMusic");
            AudioManager.instance.Play("BossBgm");
        }
    }
}
