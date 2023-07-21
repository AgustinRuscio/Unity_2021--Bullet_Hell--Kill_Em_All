//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField]
    private GameObject _punchZone;

    [SerializeField]
    protected AttackZone _attackZone;

    protected override void Attack() => _view.SetAttack();

    //Event Anim
    private void AttackOn() => _punchZone.SetActive(true);
    
    private void AttackOff() => _punchZone.SetActive(false);
    

    protected override void MoveToPlayer()
    {
        Vector3 dir = _player.position - transform.position;
        Vector3 dirWithOffset = dir + _offSet;
        dirWithOffset.Normalize();

        dirWithOffset *= FlyWeightPointer.EnemiesAtributs.enemyBaseSpeed;

        dirWithOffset.y = 0;

        transform.forward = Vector3.Lerp(transform.forward, dir, FlyWeightPointer.EnemiesAtributs.enemyRotationSpeed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, _player.position) > _offSet.magnitude + 1 && _life>0)
            _rigidBody.velocity = dirWithOffset;
        else
        {
            _rigidBody.velocity = Vector3.zero;
            Attack();
        }
    }

    protected override void SetLife() => _life = FlyWeightPointer.EnemiesAtributs.meleeEnemyMaxLife;
}