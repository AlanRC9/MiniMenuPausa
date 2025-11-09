using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Toggle fullscreenToggle;

    private void Start()
    {
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        Screen.fullScreen = isFullscreen;

        fullscreenToggle.isOn = isFullscreen;

    }

    public void OnToggleChanged(bool isOn)
    {
        Screen.fullScreen = isOn;

        PlayerPrefs.SetInt("Fullscreen", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        fullscreenToggle.onValueChanged.RemoveListener(OnToggleChanged);
    }
}
