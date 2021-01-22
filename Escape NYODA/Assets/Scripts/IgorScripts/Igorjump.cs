using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igorjump : MonoBehaviour
{
    public AudioSource jumpAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            jumpAudio.Play();
        }
    }
}
