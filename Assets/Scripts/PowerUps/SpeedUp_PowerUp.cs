//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class SpeedUp_PowerUp : PowerUp
{
    [SerializeField]
    private float _speedMultiplayer;

    [SerializeField]
    private float _buffTime;
    
    public override void Buff(PlayerModel playerToBuff) => playerToBuff.SpeedUp(_speedMultiplayer, _buffTime);
}