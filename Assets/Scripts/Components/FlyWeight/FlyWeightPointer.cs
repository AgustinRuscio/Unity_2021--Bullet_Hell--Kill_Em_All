//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------



public class FlyWeightPointer
{
    public static readonly FlyWeight EnemiesAtributs = new FlyWeight()
    {
        enemyBaseSpeed = 3,
        enemyDamage = 10,
        enemyMaxLife = 100,
        enemyRotationSpeed = 2
    };


    public static readonly FlyWeight BulletAtributs = new FlyWeight()
    {
        bulletLifeTime = 2f,
        bulletSpeed = 20f,
        bulletBaseDamage = 6,
    };
}