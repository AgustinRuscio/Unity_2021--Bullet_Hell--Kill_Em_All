using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    protected override void Attack()
    {
    }


    protected override void MoveToPlayer()
    {
        Vector3 dir = _player.position - transform.position;
        Vector3 dirWithOffset = dir + _offSet;
        dirWithOffset.Normalize();

        dirWithOffset *= FlyWeightPointer.EnemiesAtributs.enemyBaseSpeed;

        dirWithOffset.y = 0;

        transform.forward = Vector3.Lerp(transform.forward, dir, FlyWeightPointer.EnemiesAtributs.enemyRotationSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _player.position) > _offSet.magnitude)
            _rigidBody.velocity = dirWithOffset;
        else
        {
            _rigidBody.velocity = Vector3.zero;
            Attack();
        }
    }
}
