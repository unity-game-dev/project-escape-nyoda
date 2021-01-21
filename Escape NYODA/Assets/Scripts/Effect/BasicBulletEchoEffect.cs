using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletEchoEffect : MonoBehaviour
{
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject basicBulletFade;
    private Bullet bullet;

    private void Start()
    {
        bullet = GetComponent<Bullet>();
    }
    // Update is called once per frame    
    void Update()
    {
        if (bullet.isDestroyed == false)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(basicBulletFade, transform.position, Quaternion.identity);
                Destroy(instance, 0.5f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        
    }
}
