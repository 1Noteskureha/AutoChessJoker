using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Home_Battle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Treasure;

    [SerializeField]
    private Image Enemies;

    [SerializeField]
    private GameObject BattleField;

    private int Selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetStage()
    {

    }

    public void OnSelectStage(int Stage)
    {
        Selected = Stage;
        //Enemies.sprite = ;
        //Treasure.text = ;
    }

    public void GoBattle()
    {
        if (Selected == 0) return;

        BattleField.SetActive(true);
        BattleController.Instance.Initialize(DataBase.StageName[Selected]);
    }
}
