using System.Collections;
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
    private void Update()
    {
        count.text = gemCount.ToString();
        /*if(gemCount == 4)
        {
            AudioManager.instance.Play("BossBgm");
            AudioManager.instance.StopPlaying("BgMusic");
        }*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gem")
        {
            Destroy(other.gameObject);
            gemCount++;
            Debug.Log(gemCount);
        }
    }
}
