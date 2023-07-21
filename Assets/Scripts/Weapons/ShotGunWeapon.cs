//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class ShotGunWeapon : Weapon
{
    [SerializeField]
    private int bulletCount = 5;

    [SerializeField]
    private float bulletSpread = 75f;

    [SerializeField]
    private float _offSetMultiplayer = .5f;

    public override void FireWeapon(params object[] parameters)
    {
        if (Time.time >= nextFireTime)
        {
            FireAnim((bool)parameters[0]);

            if (((bool)parameters[0]))
            {
                nextFireTime = Time.time + fireRate; 
                for (int i = 0; i < bulletCount; i++)
                {
                    Vector3 positionOffset = Random.insideUnitCircle * _offSetMultiplayer;
                    Vector3 bulletPosition = _spawnPoint.position + positionOffset;

                    float spreadAngle = Random.Range(-bulletSpread, bulletSpread);
                    Quaternion rotation = Quaternion.Euler(0f, spreadAngle, 0f) * _spawnPoint.rotation;

                    BulletManager.instance.BulletFactory().MakeBullet(bulletPosition, _spawnPoint.forward, rotation, _damageMultiplayer);
                    _particleSystem.Play();
                }
            }
        }
    }
}