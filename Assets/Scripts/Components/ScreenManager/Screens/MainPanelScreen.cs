//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class MainPanelScreen : AbstractScreen
{
    [SerializeField]
    private AbstractScreen _creditsPanel = null;

    [SerializeField]
    private AbstractScreen _controllersPanel = null;


    private void Start() => ScreenManager.instance.Push(this);
    
    public void BTN_OpenCredits() => ScreenManager.instance.Push(_creditsPanel);

    public void BTN_OpenControllers() => ScreenManager.instance.Push(_controllersPanel);

    public void BTN_Quit() => Application.Quit();
}