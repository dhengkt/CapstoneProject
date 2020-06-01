using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Functions for option menu; linked with button/dropdown/click box on Options Menu
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer themeMixer;
    public AudioMixer seMixer;
    public Dropdown resoluDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        //clear the options in dropdown menu
        resoluDropdown.ClearOptions();

        List<string> options = new List<string>();

        // loop through possible resolution options
        int curResoluIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                curResoluIndex = i;
            }
        }

        resoluDropdown.AddOptions(options);
        resoluDropdown.value = curResoluIndex;
        resoluDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetThemeVolume(float volume)
    {
        themeMixer.SetFloat("volume", volume);
    }

    public void SetSEVolume(float volume)
    {
        seMixer.SetFloat("volume", volume);
    }
}
