//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class EnemyView 
{
    private Animator _animator;

    public EnemyView(Animator animator) => _animator = animator;
    
    public void SetAttack() => _animator.SetTrigger("Attack");
    public void SetThrow() => _animator.SetTrigger("Throw");
    public void SetIdle(bool idle) => _animator.SetBool("Idle", idle);
}