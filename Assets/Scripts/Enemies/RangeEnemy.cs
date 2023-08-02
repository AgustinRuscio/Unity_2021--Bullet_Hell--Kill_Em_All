//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField]
    private Transform _shootPoint;

    [SerializeField]
    private float _damageMultiplayer;

    private GenericTimer _timer;
    
    [SerializeField]
    private float _coolDown;

    [SerializeField]
    private GameObject _axePrefab;

    private void Awake() => _timer = new GenericTimer().SetCoolDown(_coolDown);  

    protected override void Update()
    {
        base.Update();
        _timer.RunTimer();
    }

    protected override void Attack() => _view.SetThrow();
    
    protected override void MoveToPlayer()
    {
        _view.SetIdle(false);

        Vector3 dir = _player.position - transform.position;
        Vector3 dirWithOffset = dir + _offSet;
        dirWithOffset.Normalize();

        dirWithOffset *= FlyWeightPointer.RangeEnemiesAtributs.meleeEnemyBaseSpeed;

        dirWithOffset.y = 0;

        transform.forward = Vector3.Lerp(transform.forward, dir, FlyWeightPointer.RangeEnemiesAtributs.meleeEnemyRotationSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _player.position) > _offSet.magnitude && _life > 0)
            _rigidBody.velocity = dirWithOffset;
        else
        {
            _view.SetIdle(true);
            _rigidBody.velocity = Vector3.zero;

            if(_timer.CheckCoolDown())
            {
                Attack();
                _timer.ResetTimer();
            }
        }
    }
    protected override void Death()
    {
        base.Death();
        _axePrefab.SetActive(false);
    }

    public void Throw() => BulletManager.instance.AxeFactory().MakeBullet(_shootPoint.position, _shootPoint.forward, transform.rotation, _damageMultiplayer);

    protected override void SetLife() => _life = FlyWeightPointer.RangeEnemiesAtributs.rangeEnemyMaxLife;
}