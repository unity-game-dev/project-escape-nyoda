using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalScript : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.02f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(waitTime < 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.02f;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            effector.rotationalOffset = 0;
        }
    }
}
