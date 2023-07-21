//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class AbstractScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private CanvasGroup myCanvasGroup;

    public virtual void Activate()
    {
        myCanvasGroup.alpha = 1.0f;
        myCanvasGroup.blocksRaycasts = true;
        myCanvasGroup.interactable = true;
    }

    public virtual void Deactivate()
    {
        myCanvasGroup.alpha = 0.0f;
        myCanvasGroup.blocksRaycasts = false;
        myCanvasGroup.interactable = false;
    }

    public virtual void Destroy()
    {
        myCanvasGroup.alpha = 0.0f;
        myCanvasGroup.blocksRaycasts = false;
        myCanvasGroup.interactable = false;
    }
}