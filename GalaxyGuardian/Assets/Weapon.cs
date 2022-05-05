using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shoot;
    public GameObject bulletPrefab;
    public Joybutton joybutton;
    public float bulletForce = 20f;

    public bool autoFire = false;
    public bool fire;
    public bool refire;

    public int maxAmmo;
    public int currentAmmo;
    
    public float refireTime = 0;
    public float reloadTime = 0;
    void Start()
    {
        joybutton = FindObjectOfType<Joybutton>();
        maxAmmo = 30;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame

    void Update()
    {
        float delta_factor = 7;

        if (fire && !joybutton.Pressed)
        {
            Debug.Log("Not Fire");
            fire = false;
            refire = autoFire;
        }
        if (!fire && joybutton.Pressed && refire)
        {
            fire = true;
            refire = false;
        }

        if(!joybutton.Pressed)
        {
            refire = true;
        }

        refireTime = Mathf.Max(0, refireTime - delta_factor);

        if (reloadTime > 0)
        {
            reloadTime = Mathf.Max(0, reloadTime - delta_factor);
            if (reloadTime == 0)
            {
                currentAmmo = maxAmmo;
            }
        }

        if (fire && reloadTime == 0)
        {
            if (currentAmmo == 0)
            {
                reloadTime = 60 * 2;
            }
            else if (refireTime == 0)
            {
                refireTime = 80;

                Shoot();

                if (currentAmmo > 0)
                    currentAmmo--;
            }
        }
    }

    //Shooting
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shoot.position, shoot.rotation * Quaternion.Euler(0, 0, 90));

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shoot.up * bulletForce, ForceMode2D.Impulse);
        //fix fire direction back into the right direction
        rb.velocity = bulletForce * transform.up;
        /*Debug.Log("shoot");*/
    }
}
