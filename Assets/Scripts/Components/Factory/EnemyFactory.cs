//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System;
using UnityEngine;

public class EnemyFactory
{
    private ObjectPool<Enemy> _enemyPool;

    private int _enemyPreWarm = 50;

    public EnemyFactory(Enemy enemy) => _enemyPool = new ObjectPool<Enemy>(enemy, _enemyPreWarm, Factory, TurnOn, TurnOff);

    public Enemy MakeEnemy(Vector3 enemyPosition, Action reduce)
    {
        Enemy newEnemy = _enemyPool.GetObjects();
        newEnemy.Initialize(enemyPosition, ReturnEnemy, reduce);
        return newEnemy;
    }

    private Enemy Factory(Enemy prefab)
    {
        Enemy newEnemy = MonoBehaviour.Instantiate(prefab);
        return newEnemy;
    }

    private void ReturnEnemy(Enemy enemyToReturn) => _enemyPool.ReturnObjects(enemyToReturn);

    private void TurnOn(Enemy enemy) => enemy.gameObject.SetActive(true);

    private void TurnOff(Enemy enemy)
    {
        enemy.ReturnEnemy();
        enemy.gameObject.SetActive(false);
    }
}