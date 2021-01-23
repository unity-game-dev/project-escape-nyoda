using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public ArmRotation armRotation;
    private Rigidbody2D rb;
    public int pAmmo = 0;
    public int sAmmo = 0;
    public Text primaryAmmo;
    public Text secondaryAmmo;
    private void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(armRotation.isPrimary == true && pAmmo > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            pAmmo--;
            primaryAmmo.text = pAmmo.ToString();
            AudioManager.instance.Play("Gun");
            CinemachineShake.Instance.ShakeCamera(6f, 0.1f);
        }
        else if(armRotation.isSecondary == true && sAmmo >0)
        {
            Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
            sAmmo--;
            secondaryAmmo.text = sAmmo.ToString();
            AudioManager.instance.Play("Missile");
            CinemachineShake.Instance.ShakeCamera(10f, 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "pAmmo")
        {
            Destroy(col.gameObject);
            pAmmo+=4;
            primaryAmmo.text = pAmmo.ToString();
        }
        if(col.tag == "sAmmo")
        {
            Destroy(col.gameObject);
            sAmmo+=2;
            secondaryAmmo.text = sAmmo.ToString();
        }
    }
}

