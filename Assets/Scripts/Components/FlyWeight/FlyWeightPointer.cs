//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------



public class FlyWeightPointer
{
    public static readonly FlyWeight MeleeEnemiesAtributs = new FlyWeight()
    {
        meleeEnemyBaseSpeed = 3,

        meleeEnemyDamage = 10,

        meleeEnemyMaxLife = 100,

        meleeEnemyRotationSpeed = 2
    };

    public static readonly FlyWeight RangeEnemiesAtributs = new FlyWeight()
    {
        rangeEnemyBaseSpeed = 3,

        rangeEnemyDamage = 10,

        rangeEnemyMaxLife = 80,

        rangeEnemyRotationSpeed = 2
    };

    public static readonly FlyWeight KamekaseEnemiesAtributs = new FlyWeight()
    {
        kamekazeEnemyBaseSpeed = 3,

        kamekazeEnemyDamage = 50,

        kamekazeEnemyMaxLife = 80,

        kamekazeEnemyRotationSpeed = 2
    };


    public static readonly FlyWeight BulletAtributs = new FlyWeight()
    {
        bulletLifeTime = 2f,

        bulletSpeed = 20f,

        bulletBaseDamage = 6,
    };
}