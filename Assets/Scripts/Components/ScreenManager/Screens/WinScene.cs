//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class WinScene : AbstractScreen
{
    [SerializeField]
    private AbstractScreen _creditsPanel = null; 
    public void BTN_OpenCredits() => ScreenManager.instance.Push(_creditsPanel);
}