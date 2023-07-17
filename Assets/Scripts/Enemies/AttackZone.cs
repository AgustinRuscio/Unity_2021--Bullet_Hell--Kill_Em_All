using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float damage = FlyWeightPointer.EnemiesAtributs.enemyDamage;

    public void SetDamage(float multiplayer)
    {
        damage *= multiplayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        var plater = other.gameObject.GetComponent<PlayerModel>();

        if (plater != null)
        {
            plater.TakeDamage(damage);
        }

    }
}
