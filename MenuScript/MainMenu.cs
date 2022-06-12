using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public void playGame()
    {
        QuestScript.questCtr = 0;
        TakeWeapon.isRifle = false;
        TakeWeapon.isPistol = false;
        TakeWeapon.takeRifle = false;
        TakeWeapon.takePistol = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void quitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        setFullScreen(true);

        List<string> options = new List<string>();

        int currResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void setFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    
    public void setQuality(int qualtiyIndex)
    {
        QualitySettings.SetQualityLevel(qualtiyIndex);
    }

}
