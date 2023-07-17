using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : Weapon
{
    public override void FireWeapon(params object[] p)
    {
        if (Time.time >= nextFireTime)
        {
            FireAnim((bool)p[0]);

            if ((bool)p[0])
            {
                BulletManager.instance.BulletFactory().MakeBullet(_spawnPoint.position, _spawnPoint.forward,_spawnPoint.rotation ,_damageMultiplayer);
                particleSystem.Play();
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}