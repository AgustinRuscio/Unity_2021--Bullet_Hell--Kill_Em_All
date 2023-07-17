using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    private void OnCollisionEnter(Collision collision)
    {
        var Damageable = collision.gameObject.GetComponent<IDamageable>();

        Damageable?.TakeDamage(_damage);

        if (collision.gameObject.GetComponent<Bullet>() == null)
            DestroyBullet();
    }
}
