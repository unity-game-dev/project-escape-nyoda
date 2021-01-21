﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCount : MonoBehaviour
{
    private Rigidbody2D rb;
    public int gemCount = 0;
    public Text count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gem")
        {
            Destroy(other.gameObject);
            gemCount++;
            count.text = gemCount.ToString();
        }
    }
}
