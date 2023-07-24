//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class RocketLuncherWeapon : Weapon
{
    public override void FireWeapon(params object[] parameters)
    {
        if (Time.time >= nextFireTime)
        {
            FireAnim((bool)parameters[0]);

            if ((bool)parameters[0])
            {
                BulletManager.instance.RcoketFactory().MakeBullet(_spawnPoint.position, _spawnPoint.forward, _spawnPoint.rotation, _damageMultiplayer);
                _particleSystem.Play();
                _audioSource.Play();
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
