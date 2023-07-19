//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------



public class FlyWeightPointer
{
    public static readonly FlyWeight EnemiesAtributs = new FlyWeight()
    {
        enemyBaseSpeed = 3,

        meleeEnemyDamage = 10,
        kamekazeEnemyDamage = 50,

        meleeEnemyMaxLife = 100,
        rangeEnemyMaxLife = 80,

        enemyRotationSpeed = 2
    };


    public static readonly FlyWeight BulletAtributs = new FlyWeight()
    {
        bulletLifeTime = 2f,
        bulletSpeed = 20f,
        bulletBaseDamage = 6,
    };
}