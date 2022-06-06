using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{

    [SerializeField]
    public GameObject menu;
    [SerializeField]
    public GameObject menuBack;

    //図鑑
    public GameObject dictMenu;

    //グラフィック設定
    [SerializeField]
    public GameObject screenMenu;

    //サウンド設定
    [SerializeField]
    public GameObject soundMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //メニュー表示をトグルする
    public void MenuToggle()
    {
        Debug.Log("?");
        menu.SetActive(!menu.activeSelf);
        menuBack.SetActive(!menuBack.activeSelf);

        if(BattleController.Instance != null)
        BattleController.Instance.gameStop = menu.activeSelf;
    }

    //メニュー表示を消す
    public void MenuClose()
    {
        menu.SetActive(false);
    }

    public void OnScreenSetting()
    {
        screenMenu.SetActive(true);
    }

    public void OnSoundSetting()
    {
        soundMenu.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
