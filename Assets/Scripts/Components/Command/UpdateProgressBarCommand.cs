using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProgressBarCommand : ICommand
{
    private ProgressBar _progressBar;

    public UpdateProgressBarCommand(ProgressBar progressBar) => _progressBar = progressBar;
    
    public void Execute(float progress) => _progressBar.UpdateProgress(progress);
}