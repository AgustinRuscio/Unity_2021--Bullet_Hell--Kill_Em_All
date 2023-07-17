//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance { get; private set; }
    private Stack<IScreen> screensStack = new Stack<IScreen>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public void Push(IScreen screen)
    {
        if (screensStack.Count > 0)
            screensStack.Peek().Deactivate();


        screensStack.Push(screen);
        screen.Activate();
    }

    public void Pop()
    {
        if (screensStack.Count <= 0) return;

        screensStack.Pop().Destroy();

        if (screensStack.Count >= 1)
            screensStack.Peek().Activate();
    }
}