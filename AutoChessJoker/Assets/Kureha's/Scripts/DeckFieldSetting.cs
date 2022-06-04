using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckFieldSetting : MonoBehaviour
{
    [SerializeField]
    List<Image> Fields;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        Fields[0].sprite = DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front1")].sprite;
        Fields[1].sprite = DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front2")].sprite;
        Fields[2].sprite = DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front3")].sprite;
        Fields[3].sprite = DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back1")].sprite;
        Fields[4].sprite = DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back2")].sprite;
        Fields[5].sprite = DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back3")].sprite;
    }
}
