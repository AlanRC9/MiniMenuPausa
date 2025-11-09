using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public CanvasGroup canvasGroup;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else Resume();
        }
    }

    public void Pause()
    {
        isPaused = true;
        StartCoroutine(FadeCanvas(canvasGroup.alpha, 1, true));
    }

    public void Resume()
    {
        isPaused = false;
        StartCoroutine(FadeCanvas(canvasGroup.alpha, 0, false));
        
        
    }

    private System.Collections.IEnumerator FadeCanvas(float actualAlpha, float finalAlpha, bool canvasFinalState)
    {
        float time = 0f;
        float duration = 0.5f;

        if (canvasFinalState)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;

            while (time < duration)
            {
                time += Time.unscaledDeltaTime;
                canvasGroup.alpha = Mathf.Lerp(actualAlpha, finalAlpha, time / duration);
                yield return null;
            }
        }
        else
        {
            while (time < duration)
            {
                time += Time.unscaledDeltaTime;
                canvasGroup.alpha = Mathf.Lerp(actualAlpha, finalAlpha, time / duration);
                yield return null;
            }
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }

        canvasGroup.alpha = finalAlpha;
    }
}
