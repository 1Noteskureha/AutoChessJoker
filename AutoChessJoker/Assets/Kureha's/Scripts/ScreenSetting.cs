using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenSetting : MonoBehaviour
{
    bool screenType;
    int screenSizeX = Screen.width;
    int screenSizeY = Screen.height;

    [SerializeField]
    private Toggle fullScreenToggle;

    [SerializeField]
    private TMP_Dropdown sizeDropDown;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenToggle.isOn = Screen.fullScreen ? true : false;

        switch (Screen.width)
        {
            case 1920:
                sizeDropDown.value = 0;
                break;
            case 1280:
                sizeDropDown.value = 1;
                break;
            case 640:
                sizeDropDown.value = 2;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        if(Screen.fullScreen) screenType = true;
        else screenType = false;
        screenSizeX = Screen.width;
        screenSizeY = Screen.height;

    }

    public void ToggleFullScreen()
    {
        screenType = !screenType;
    }

    //スクリーンサイズ変更
    public void OnChangeScreenSize(int Value)
    {
        Debug.Log(Value);
        switch (Value)
        {
            case 0:
                screenSizeX = 1920;
                screenSizeY = 1080;
                break;
            case 1:
                screenSizeX = 1280;
                screenSizeY = 720;
                break;
            case 2:
                screenSizeX = 640;
                screenSizeY = 360;
                break;
        }
    }

    public void Apply()
    {
        if (screenType) Screen.fullScreenMode = FullScreenMode.Windowed;
        else Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        Screen.SetResolution(screenSizeX,screenSizeY,Screen.fullScreenMode);

        this.gameObject.SetActive(false);
    }

    public void NoApply()
    {
        this.gameObject.SetActive(false);

    }
}
