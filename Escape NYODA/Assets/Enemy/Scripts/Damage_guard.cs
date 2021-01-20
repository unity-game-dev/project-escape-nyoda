using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_guard : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            IgorHealth enemy = trig.GetComponent<IgorHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(15);
            }
        }
    }
}
