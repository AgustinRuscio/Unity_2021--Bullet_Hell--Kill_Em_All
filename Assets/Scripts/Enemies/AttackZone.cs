//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerModel>();

        if (player != null && !player.shield)
            player.TakeDamage(FlyWeightPointer.MeleeEnemiesAtributs.meleeEnemyDamage);
    }
}