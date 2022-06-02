using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : SingletonMonoBehaviour<BattleController>
{
    //ステージと深度
    public Stage stage;

    [HideInInspector]
    public int progress;

    //ハンドル
    public List<Effect> first;
    public List<Effect> turnFirst;
    public List<Effect> turnEnd;

    public List<Monster> allyField;
    public List<Monster> enemyField;

    public List<Image> allyImage;
    public List<Image> enemyImage;

    public List<Monster> allyMonsters;
    public List<Monster> enemyMonsters;

    public List<string> log;
    public Queue<int> spdQueue;     //0~5 = 味方、6~11 = 敵
    private Coroutine Turn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Stage _stage)
    {
        stage = _stage;
        progress = 0;

        //モンスター召喚
        SummonAllyMonsters();
        SummonEnemyMonsters();

        //シンボルの計算

        //最初のハンドル消化

        StartCoroutine(TurnAction());
    }

    public void AddLog(string s)
    {
        log.Add((log.Count+1) + ": " + s);
    }

    private IEnumerator TurnAction()
    {
        while (true)
        {
            //ターン初めのハンドル消化

            //行動順計算
            SpdDecide();
            //通常攻撃
            //スキル
            while (!AllDone())
            {
                if (spdQueue.Count == 0) break;
                int target = spdQueue.Dequeue();
                if (target < 6)
                {
                    allyField[target].Move();
                }
                else
                {
                    enemyField[target - 6].Move();
                }

                yield return new WaitForSeconds(0.5f);
            }


            //ターン終了時のハンドル消化
        }

        yield break;
    }

    //行動が済んでいるか判定
    private bool AllDone()
    {
        foreach (var enemy in enemyField)
        {
            if (!enemy.done) return false;
        }
        foreach (var ally in allyField)
        {
            if (!ally.done) return false;
        }

        return true;
    }

    //行動順計算
    private void SpdDecide()
    {
        spdQueue = new Queue<int>();
        List<Monster> monsters = new List<Monster>();
        foreach (var enemy in enemyField)
        {
            monsters.Add(enemy);
        }
        foreach (var ally in allyField)
        {
            monsters.Add(ally);
        }


        int max = 0;
        int _ally = 0;
        int position = 0;
        List<bool> calced = new List<bool>(monsters.Count);
        for (int j = 0; j < monsters.Count; j++)
        {

            int tmp = -1;
            for (int i = 0; i < monsters.Count; i++)
            {
                if (max >= monsters[i].spd && !monsters[i].done && calced[i] == false)
                {
                    max = monsters[i].spd;
                    if (monsters[i].ally)
                    {
                        _ally = 0;
                    }
                    else
                    {
                        _ally = 6;
                    }
                    position = monsters[i].field;
                    tmp = j;
                }
            }

            if (tmp == -1) return;
            calced[tmp] = true;
            spdQueue.Enqueue(_ally + position);
        }
    }

    public void MonsterDead(bool ally,int field)
    {
        if (ally)
        {
            allyImage[field].sprite = Resources.Load<Sprite>("Monster/blank");

            if (allyField[0].living == false && allyField[1].living == false && allyField[2].living == false && allyField[3].living == false && allyField[4].living == false && allyField[5].living == false)
            {
                GameOver();
                return;
            }
            if(allyField[0].living == false && allyField[1].living == false && allyField[2].living == false)
            {
                var tmp = allyField[0];
                allyField[0] = allyField[3];
                allyField[3] = tmp;
                allyImage[0].sprite = allyField[0].sprite;
                allyImage[3].sprite = allyField[3].sprite;

                tmp = allyField[1];
                allyField[1] = allyField[4];
                allyField[4] = tmp;
                allyImage[1].sprite = allyField[1].sprite;
                allyImage[4].sprite = allyField[4].sprite;

                tmp = allyField[2];
                allyField[2] = allyField[5];
                allyField[5] = tmp;
                allyImage[2].sprite = allyField[2].sprite;
                allyImage[5].sprite = allyField[5].sprite;
            }
        }
        else
        {
            enemyImage[field].sprite = Resources.Load<Sprite>("Monster/blank");

            if (enemyField[0].living == false && enemyField[1].living == false && enemyField[2].living == false && enemyField[3].living == false && enemyField[4].living == false && enemyField[5].living == false)
            {
                Clear();
                return;
            }
            if (enemyField[0].living == false && enemyField[1].living == false && enemyField[2].living == false)
            {
                var tmp = enemyField[0];
                enemyField[0] = enemyField[3];
                enemyField[3] = tmp;
                enemyImage[0].sprite = enemyField[0].sprite;
                enemyImage[3].sprite = enemyField[3].sprite;

                tmp = enemyField[1];
                enemyField[1] = enemyField[4];
                enemyField[4] = tmp;
                enemyImage[1].sprite = enemyField[1].sprite;
                enemyImage[4].sprite = enemyField[4].sprite;

                tmp = enemyField[2];
                enemyField[2] = enemyField[5];
                enemyField[5] = tmp;
                enemyImage[2].sprite = enemyField[2].sprite;
                enemyImage[5].sprite = enemyField[5].sprite;
            }
        }

        SpdDecide();
    }
    
    //全滅
    private void GameOver()
    {
        //戻る
    }

    //敵全滅(ステージクリア)
    private void Clear()
    {
        //エッセンス獲得
        GetEssense();

        progress++;
        if(progress > stage.enemyFields.Count)
        {   
            //アンロック
            //戻る
        }
    }

    private void GetEssense()
    {
        PlayerPrefs.SetInt("Essense_A",PlayerPrefs.GetInt("Essense_A") + stage.essense[progress][0]);
        PlayerPrefs.SetInt("Essense_B",PlayerPrefs.GetInt("Essense_B") + stage.essense[progress][1]);
        PlayerPrefs.SetInt("Essense_C",PlayerPrefs.GetInt("Essense_C") + stage.essense[progress][2]);
        PlayerPrefs.SetInt("Essense_D",PlayerPrefs.GetInt("Essense_D") + stage.essense[progress][3]);
        PlayerPrefs.SetInt("Essense_E",PlayerPrefs.GetInt("Essense_E") + stage.essense[progress][4]);
        PlayerPrefs.SetInt("Essense_F",PlayerPrefs.GetInt("Essense_F") + stage.essense[progress][5]);
        PlayerPrefs.SetInt("Essense_G",PlayerPrefs.GetInt("Essense_G") + stage.essense[progress][6]);
        PlayerPrefs.SetInt("Essense_H",PlayerPrefs.GetInt("Essense_H") + stage.essense[progress][7]);
        PlayerPrefs.SetInt("Essense_I",PlayerPrefs.GetInt("Essense_I") + stage.essense[progress][8]);
    }

    //戦闘初めに味方モンスターの召喚
    private void SummonAllyMonsters()
    {
        allyField = new List<Monster>(6);
        allyMonsters = new List<Monster>();

        for(int i=0;i<6;i++)
        {
            allyField[i] = new Blank();
        }

        if (PlayerPrefs.GetInt("Bt_Front1") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front1")]);            
            allyField[0] = (allyMonsters[allyMonsters.Count - 1]);
            allyField[0].ally = true;
            allyField[0].field = 0;
        }
        if (PlayerPrefs.GetInt("Bt_Front2") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front2")]);
            allyField[1] = (allyMonsters[allyMonsters.Count - 1]);
            allyField[1].ally = true;
            allyField[1].field = 1;
        }
        if (PlayerPrefs.GetInt("Bt_Front3") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Front3")]);
            allyField[2] = (allyMonsters[allyMonsters.Count - 1]);
            allyField[2].ally = true;
            allyField[2].field = 2;
        }
        if (PlayerPrefs.GetInt("Bt_Back1") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back1")]);
            allyField[3] = (allyMonsters[allyMonsters.Count - 1]);
            allyField[3].ally = true;
            allyField[3].field = 3;
        }
        if (PlayerPrefs.GetInt("Bt_Back2") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back2")]);
            allyField[4] = (allyMonsters[allyMonsters.Count - 1]);
            allyField[4].ally = true;
            allyField[4].field = 4;
        }
        if (PlayerPrefs.GetInt("Bt_Back3") != 0)
        {
            allyMonsters.Add(DataBase.noToMonster[PlayerPrefs.GetInt("Bt_Back3")]);
            allyField[5] = (allyMonsters[allyMonsters.Count - 1]);
            allyField[5].ally = true;
            allyField[5].field = 5;
        }
    }

    private void SummonEnemyMonsters()
    {
        enemyField = new List<Monster>(6);

        for(int i=0;i<6;i++)
        {
            enemyField[i] = new Blank();
        }

        for (int i = 0; i < 6; i++)
        {
            enemyMonsters.Add(stage.enemyFields[progress][i]);
            enemyField[i] = (enemyMonsters[enemyMonsters.Count - 1]);
            enemyField[i].ally = false;
            enemyField[i].field = 0;

        }
    }
}
