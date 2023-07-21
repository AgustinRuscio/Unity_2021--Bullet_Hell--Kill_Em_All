//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class BulletFactory
{
    private ObjectPool<Bullet> _bulletPool;

    private int _bulletsPreWarm = 150;
 
    public BulletFactory(Bullet bullet) => _bulletPool = new ObjectPool<Bullet>(bullet, _bulletsPreWarm, Factory, TurnOn, TurnOff);
    
    public Bullet MakeBullet(Vector3 bulletPosition, Vector3 fwd, Quaternion rotation ,float multiplayer)
    {
        Bullet newBullet = _bulletPool.GetObjects();
        newBullet.Initialize(bulletPosition, ReturnBullet, fwd, rotation,multiplayer);
        return newBullet;
    }

    private Bullet Factory(Bullet prefab)
    {
        Bullet newBullet = MonoBehaviour.Instantiate(prefab);
        return newBullet;
    }

    private void ReturnBullet(Bullet bulletToReturn) => _bulletPool.ReturnObjects(bulletToReturn);

    private void TurnOn(Bullet bullet) => bullet.gameObject.SetActive(true);

    private void TurnOff(Bullet bullet)
    {
        bullet.ReturnBullet();
        bullet.gameObject.SetActive(false);
    }
}