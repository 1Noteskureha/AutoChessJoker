using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{

    [SerializeField]
    public GameObject menu;
    [SerializeField]
    public GameObject menuBack;

    //�}��
    public GameObject dictMenu;

    //�O���t�B�b�N�ݒ�
    [SerializeField]
    public GameObject screenMenu;

    //�T�E���h�ݒ�
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

    //���j���[�\�����g�O������
    public void MenuToggle()
    {
        Debug.Log("?");
        menu.SetActive(!menu.activeSelf);
        menuBack.SetActive(!menuBack.activeSelf);

        if(BattleController.Instance != null)
        BattleController.Instance.gameStop = menu.activeSelf;
    }

    //���j���[�\��������
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
