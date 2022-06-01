using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : SingletonMonoBehaviour<BattleController>
{   
    //ハンドル
    public List<Effect> first;
    public List<Effect> turnFirst;
    public List<Effect> turnEnd;

    public List<Monster> allyField;
    public List<Monster> enemyField;

    public List<Monster> allyMonsters;
    public List<Monster> enemyMonsters;

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

        //モンスター召喚
        SummonAllyMonsters();        

        //最初のハンドル消化
    }

    private void TurnAction()
    {
        while (true)
        {
            //ターン初めのハンドル消化

            //通常攻撃
            //スキル

            //ターン終了時のハンドル消化
        }
    }

    private void SummonAllyMonsters()
    {
        allyField = new List<Monster>(6);
        allyMonsters = new List<Monster>();

        if (PlayerPrefs.GetInt("Bt_Front1") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front1")]);
            allyField[0] = (allyMonsters[allyMonsters.Count - 1]);
        }
        if (PlayerPrefs.GetInt("Bt_Front2") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front2")]);
            allyField[1] = (allyMonsters[allyMonsters.Count - 1]);
        }
        if (PlayerPrefs.GetInt("Bt_Front3") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front3")]);
            allyField[2] = (allyMonsters[allyMonsters.Count - 1]);
        }
        if (PlayerPrefs.GetInt("Bt_Back1") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back1")]);
            allyField[3] = (allyMonsters[allyMonsters.Count - 1]);
        }
        if (PlayerPrefs.GetInt("Bt_Back2") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back2")]);
            allyField[4] = (allyMonsters[allyMonsters.Count - 1]);
        }
        if (PlayerPrefs.GetInt("Bt_Back3") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back3")]);
            allyField[5] = (allyMonsters[allyMonsters.Count - 1]);
        }
    }

    private void SummonEnemyMonsters()
    {

    }
}
