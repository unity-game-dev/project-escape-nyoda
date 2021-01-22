using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkSound : MonoBehaviour
{
      public AudioSource someSound; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D)){
            someSound.Play();
            someSound.loop = true;
        }
        else if (Input.GetKeyUp (KeyCode.A)||Input.GetKeyUp (KeyCode.D)) {
         someSound.Stop ();
     }
    }
}
