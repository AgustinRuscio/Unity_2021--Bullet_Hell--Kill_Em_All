//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using UnityEngine.SceneManagement;


public class ControllerPanel : AbstractScreen
{
    [SerializeField]
    private string sceneToLoad;

    public void BTN_Play() => SceneManager.LoadScene(sceneToLoad);

    public void BTN_Back() => ScreenManager.instance.Pop();
}