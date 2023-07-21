//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class GenericTimer
{
    private float timer;

    private float coolDown;

    public GenericTimer SetCoolDown(float _coolDown)
    {
        coolDown = _coolDown;
        return this;
    }

    public void RunTimer() => timer = timer + 1 * Time.deltaTime;

    public bool CheckCoolDown()
    {
        if(timer > coolDown)
            return true;   
        else 
            return false;
    }

    public void ResetTimer() => timer = 0;
}