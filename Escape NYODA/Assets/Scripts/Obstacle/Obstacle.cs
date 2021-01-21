using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GemCount gCount;
    // Start is called before the first frame update
    void Start()
    {
        gCount = GameObject.FindGameObjectWithTag("Player").GetComponent<GemCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gCount.gemCount == 4)
        {
            Destroy(gameObject);
        }
    }


}
