using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Bullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            DestroyBullet();
            Debug.Log("Shield");
        }

        var Damageable = other.gameObject.GetComponent<IDamageable>();

        Damageable?.TakeDamage(_damage);

        if (other.gameObject.GetComponent<Bullet>() == null)
            DestroyBullet();
    }
}