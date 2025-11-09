using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class ResolutionDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] allResolutions;
    private List<Resolution> filteredResolutions = new List<Resolution>();
    private int currentResolutionIndex = 0;

    private void Start()
    {
        allResolutions = Screen.resolutions;

        for (int i = 0; i < allResolutions.Length; i++)
        {
            Resolution resolution = allResolutions[i];
            bool exists = false;

            foreach (Resolution comparedResolution in filteredResolutions)
            {
                if (comparedResolution.width == resolution.width && comparedResolution.height == resolution.height)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
                filteredResolutions.Add(resolution);
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            Resolution resolution = filteredResolutions[i];
            string option = resolution.width + " x " + resolution.height;
            options.Add(option);

            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);

        int savedWidth = PlayerPrefs.GetInt("ResolutionWidth", 0);
        int savedHeight = PlayerPrefs.GetInt("ResolutionHeight", 0);

        if (savedWidth != 0 && savedHeight != 0)
        {
            for (int i = 0; i < filteredResolutions.Count; i++)
            {
                Resolution resolution = filteredResolutions[i];
                if (resolution.width == savedWidth && resolution.height == savedHeight)
                {
                    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
                    currentResolutionIndex = i;
                    break;
                }
            }
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void OnResolutionChanged(int index)
    {
        Resolution resolution = filteredResolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
        PlayerPrefs.Save();
    }
}
