using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_healtBar : MonoBehaviour
{
    GameObject guard;
    Guard_behaviour enemy;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        guard = GameObject.FindGameObjectWithTag("Guard");
        enemy = guard.GetComponent<Guard_behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = ((4*enemy.currentHealth) / enemy.maxHealth);
        transform.localScale = localScale;
    }
}
