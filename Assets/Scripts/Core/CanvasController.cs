//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public void BTN_Resume() => EventManager.Trigger(EventEnum.PauseGame, false);
    public void BTN_Retry() => EventManager.Trigger(EventEnum.RetryLevel);
    public void BTN_Menu() => EventManager.Trigger(EventEnum.BackToMenu);
    public void BTN_NextLevel() => EventManager.Trigger(EventEnum.NextLevel);
}