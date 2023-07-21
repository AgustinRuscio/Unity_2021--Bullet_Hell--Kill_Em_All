//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------



using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScreen : AbstractScreen
{
    [SerializeField]
    private string _levelToLoad;

    public void BTN_LoadScene() => SceneManager.LoadScene(_levelToLoad);
}