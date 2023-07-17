using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView 
{
    private Animator _animator;

    public EnemyView(Animator animator)
    {
        _animator = animator;
    }

    public void SetAttack() => _animator.SetTrigger("Attack");

}