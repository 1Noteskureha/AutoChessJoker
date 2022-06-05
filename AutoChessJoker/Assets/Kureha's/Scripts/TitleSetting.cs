using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        PlayerPrefs.SetInt("Init",0);
#endif  

        //èâãNìÆ
        if(PlayerPrefs.GetInt("Init") == 0)
        {   
            
            PlayerPrefs.SetInt("Bt_Front1",1000);
            PlayerPrefs.SetInt("Bt_Front2",1000);
            PlayerPrefs.SetInt("Bt_Front3",1000);
            PlayerPrefs.SetInt("Bt_Back1",1000);
            PlayerPrefs.SetInt("Bt_Back2",1000);
            PlayerPrefs.SetInt("Bt_Back3",1000);
            PlayerPrefs.SetInt("Bt_Support1",1000);
            PlayerPrefs.SetInt("Bt_Support2", 1000);
            PlayerPrefs.SetInt("Bt_Support3", 1000);
            PlayerPrefs.SetInt("Bt_Support4", 1000);

            PlayerPrefs.SetInt("Essense_A",0);
            PlayerPrefs.SetInt("Essense_B",0);
            PlayerPrefs.SetInt("Essense_C",0);
            PlayerPrefs.SetInt("Essense_D",0);
            PlayerPrefs.SetInt("Essense_E",0);
            PlayerPrefs.SetInt("Essense_F",0);
            PlayerPrefs.SetInt("Essense_G",0);
            PlayerPrefs.SetInt("Essense_H",0);
            PlayerPrefs.SetInt("Essense_I",0);

            PlayerPrefs.SetInt("Stage_Unlock", 1);
            PlayerPrefs.SetInt("Stage_Clear", 0);

            for(int i = 1; i <= 100; i++)
            {
                PlayerPrefs.SetInt("Dict_Unlock" + i, 0);
                PlayerPrefs.SetInt("Inventory_Monster" + i, 0);
            }

            PlayerPrefs.SetInt("Screen_Size" , 1920);
            PlayerPrefs.SetInt("Screen_FullScreen" , 0);

            PlayerPrefs.SetInt("Init",1);

#if UNITY_EDITOR
            PlayerPrefs.SetInt("Inventory_Monster1",1000);
            PlayerPrefs.SetInt("Inventory_Monster2",2000);
            PlayerPrefs.SetInt("Inventory_Monster4",1002);
            PlayerPrefs.SetInt("Inventory_Monster20",1001);
#endif
        }

        DataBase.Init();

        SceneManager.LoadSceneAsync("MainScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
