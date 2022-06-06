using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Home_Battle : SingletonMonoBehaviour<Home_Battle>
{
    [SerializeField]
    private TMP_Text treasure;

    [SerializeField]
    private Image enemies;

    [SerializeField]
    private GameObject battleField;

    //ƒvƒŒƒnƒu
    [SerializeField]
    private GameObject PrefabButton;
    [SerializeField]
    private Transform Content;

    private int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= PlayerPrefs.GetInt("Stage_Unlock"); i++)
        {
            GenerateStage(i);
        }

        SelectStage();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateStage(int stage)
    {
        GameObject tmp = Instantiate(PrefabButton,Content);
        tmp.GetComponent<StageButton>().Init(stage);
    }

    private void SelectStage()
    {   
        if(selected == 0)
        {
            treasure.text = "";
            enemies.sprite = null;
            return;
        }
        treasure.text = new Stage(selected).description;
        enemies.sprite = new Stage(selected).sprite;
    }

    public void OnSelectStage(int Stage)
    {
        selected = Stage;

        SelectStage();
    }

    public void GoBattle()
    {
        if (selected == 0) return;

        battleField.SetActive(true);
        BattleController.Instance.Initialize(new Stage(selected));
        selected = 0;
    }

}
