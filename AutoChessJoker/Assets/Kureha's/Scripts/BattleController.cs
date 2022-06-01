using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : SingletonMonoBehaviour<BattleController>
{   
    //�n���h��
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

        //�����X�^�[����
        SummonAllyMonsters();        

        //�ŏ��̃n���h������
    }

    private void TurnAction()
    {
        while (true)
        {
            //�^�[�����߂̃n���h������

            //�ʏ�U��
            //�X�L��

            //�^�[���I�����̃n���h������
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
