using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFieldSetting : MonoBehaviour
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
        Fields[0].sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Bt_Front1"));
    }
}
