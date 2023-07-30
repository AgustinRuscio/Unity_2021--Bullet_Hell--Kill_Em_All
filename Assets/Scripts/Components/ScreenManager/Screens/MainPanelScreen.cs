//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanelScreen : AbstractScreen
{
    [SerializeField]
    private AbstractScreen _creditsPanel = null;

    [SerializeField]
    private AbstractScreen _controllersPanel = null;

    [SerializeField]
    private GameObject _continueBTN;

    private void Awake() => UpdateBTNState();
    

    private void UpdateBTNState()
    {
        if (PlayerPrefs.GetString("CurrentLevel") == string.Empty)
            _continueBTN.SetActive(false);
        else
            _continueBTN.SetActive(true);
    }


    private void Start() => ScreenManager.instance.Push(this);
    
    public void BTN_OpenCredits() => ScreenManager.instance.Push(_creditsPanel);

    public void BTN_OpenControllers() => ScreenManager.instance.Push(_controllersPanel);

    public void BTN_Continue() => SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    public void BTN_DeleteData()
    {
        PlayerPrefs.DeleteAll();
        UpdateBTNState();
    }

    public void BTN_Quit() => Application.Quit();
}