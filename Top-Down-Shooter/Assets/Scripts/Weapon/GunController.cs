using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public Transform firePoint;

    void Update()
    {
        if(isFiring && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;

        }
    }
}
