//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class NormalBullet : Bullet
{
    private void OnCollisionEnter(Collision collision)
    {
        var Damageable = collision.gameObject.GetComponent<IDamageable>();
        var player = collision.gameObject.GetComponent<PlayerModel>();

        if(player == null)
            Damageable?.TakeDamage(_damage);

        if (collision.gameObject.GetComponent<Bullet>() == null)
            DestroyBullet();
    }
}
