using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float progress = 0f;

    private Slider progressSlider;

    private void Awake() => progressSlider = GetComponent<Slider>();
 
    public void UpdateProgress(float targetProgress) => StartCoroutine(UpdateProgressCoroutine(targetProgress));

    private IEnumerator UpdateProgressCoroutine(float targetProgress)
    {
        while (Mathf.Abs(progress - targetProgress) > 0.01f)
        {
            progress = Mathf.MoveTowards(progress, targetProgress, Time.deltaTime);

            progressSlider.value = progress;
            yield return null;
        }
    }
}