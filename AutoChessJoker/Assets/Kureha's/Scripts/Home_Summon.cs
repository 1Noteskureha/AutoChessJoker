using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Home_Summon : SingletonMonoBehaviour<Home_Summon>
{   
    //タブ
    [SerializeField]
    private GameObject Summon;
    [SerializeField]
    private GameObject Match;
    [SerializeField]
    private GameObject Evolve;
    [SerializeField]
    private GameObject Delete;

    //インベントリ又はスクロールを開く
    [SerializeField]
    private GameObject SummonScrollPick;
    [SerializeField]
    private GameObject MatchInventoryPick;
    [SerializeField]
    private GameObject EvolveInventoryPick;
    [SerializeField]
    private GameObject DeleteInventoryPick;

    //Summon
    [SerializeField]
    private Image SummonMonster;

    private int SummonNo = -1;

    //Match
    [SerializeField]
    private Image MatchMonsterLeft;
    [SerializeField]
    private Image MatchMonsterRight;
    [SerializeField]
    private Image MatchMonsterAfter;

    private int MatchNo1 = -1;
    private int MatchNo2 = -1;

    //Evolve
    [SerializeField]
    private Image EvolveMonster;
    [SerializeField]
    private Image EvolveMonsterAfter;

    private int EvolveNo = -1;

    //Delete
    [SerializeField]
    private Image DeleteMonster;

    private int DeleteNo = -1;

    //エッセンス表示(消費or増加量)
    [SerializeField]
    private List<TMP_Text> essense;

    // Start is called before the first frame update
    void Start()
    {
        EssenseUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSummon()
    {
        Summon.SetActive(true);
        Match.SetActive(false);
        Evolve.SetActive(false);
        Delete.SetActive(false);
        OnSelectSummonMonster(SummonNo);
    }

    public void OnMatch()
    {
        Summon.SetActive(false);
        Match.SetActive(true);
        Evolve.SetActive(false);
        Delete.SetActive(false);
        EssenseUpdate();
    }

    public void OnEvolve()
    {
        Summon.SetActive(false);
        Match.SetActive(false);
        Evolve.SetActive(true);
        Delete.SetActive(false);
        EssenseUpdate();
    }

    public void OnDelete()
    {
        Summon.SetActive(false);
        Match.SetActive(false);
        Evolve.SetActive(false);
        Delete.SetActive(true);
        OnSelectDeleteMonster(DeleteNo);
    }

    public void OnEnable()
    {
        EssenseUpdate();
    }

    private void EssenseUpdate()
    {
        essense[0].text = $"{PlayerPrefs.GetInt("Essense_A")}";
        essense[1].text = $"{PlayerPrefs.GetInt("Essense_B")}";
        essense[2].text = $"{PlayerPrefs.GetInt("Essense_C")}";
        essense[3].text = $"{PlayerPrefs.GetInt("Essense_D")}";
        essense[4].text = $"{PlayerPrefs.GetInt("Essense_E")}";
        essense[5].text = $"{PlayerPrefs.GetInt("Essense_F")}";
        essense[6].text = $"{PlayerPrefs.GetInt("Essense_G")}";
        essense[7].text = $"{PlayerPrefs.GetInt("Essense_H")}";
        essense[8].text = $"{PlayerPrefs.GetInt("Essense_I")}";
    }

    private void EssenseUpdate(bool reverse,List<int> value)
    {
        if (!reverse)
        {
            essense[0].text = value[0] < 0 ? $"{PlayerPrefs.GetInt("Essense_A")} + {value[0]}" : $"{PlayerPrefs.GetInt("Essense_A")} - {value[0]}";
            essense[1].text = value[1] < 0 ? $"{PlayerPrefs.GetInt("Essense_B")} + {value[1]}" : $"{PlayerPrefs.GetInt("Essense_B")} - {value[1]}";
            essense[2].text = value[2] < 0 ? $"{PlayerPrefs.GetInt("Essense_C")} + {value[2]}" : $"{PlayerPrefs.GetInt("Essense_C")} - {value[2]}";
            essense[3].text = value[3] < 0 ? $"{PlayerPrefs.GetInt("Essense_D")} + {value[3]}" : $"{PlayerPrefs.GetInt("Essense_D")} - {value[3]}";
            essense[4].text = value[4] < 0 ? $"{PlayerPrefs.GetInt("Essense_E")} + {value[4]}" : $"{PlayerPrefs.GetInt("Essense_E")} - {value[4]}";
            essense[5].text = value[5] < 0 ? $"{PlayerPrefs.GetInt("Essense_F")} + {value[5]}" : $"{PlayerPrefs.GetInt("Essense_F")} - {value[5]}";
            essense[6].text = value[6] < 0 ? $"{PlayerPrefs.GetInt("Essense_G")} + {value[6]}" : $"{PlayerPrefs.GetInt("Essense_G")} - {value[6]}";
            essense[7].text = value[7] < 0 ? $"{PlayerPrefs.GetInt("Essense_H")} + {value[7]}" : $"{PlayerPrefs.GetInt("Essense_H")} - {value[7]}";
            essense[8].text = value[8] < 0 ? $"{PlayerPrefs.GetInt("Essense_I")} + {value[8]}" : $"{PlayerPrefs.GetInt("Essense_I")} - {value[8]}";
        }
        else
        {
            essense[0].text = value[0] < 0 ? $"{PlayerPrefs.GetInt("Essense_A")} - {value[0]}" : $"{PlayerPrefs.GetInt("Essense_A")} + {value[0]}";
            essense[1].text = value[1] < 0 ? $"{PlayerPrefs.GetInt("Essense_B")} - {value[1]}" : $"{PlayerPrefs.GetInt("Essense_B")} + {value[1]}";
            essense[2].text = value[2] < 0 ? $"{PlayerPrefs.GetInt("Essense_C")} - {value[2]}" : $"{PlayerPrefs.GetInt("Essense_C")} + {value[2]}";
            essense[3].text = value[3] < 0 ? $"{PlayerPrefs.GetInt("Essense_D")} - {value[3]}" : $"{PlayerPrefs.GetInt("Essense_D")} + {value[3]}";
            essense[4].text = value[4] < 0 ? $"{PlayerPrefs.GetInt("Essense_E")} - {value[4]}" : $"{PlayerPrefs.GetInt("Essense_E")} + {value[4]}";
            essense[5].text = value[5] < 0 ? $"{PlayerPrefs.GetInt("Essense_F")} - {value[5]}" : $"{PlayerPrefs.GetInt("Essense_F")} + {value[5]}";
            essense[6].text = value[6] < 0 ? $"{PlayerPrefs.GetInt("Essense_G")} - {value[6]}" : $"{PlayerPrefs.GetInt("Essense_G")} + {value[6]}";
            essense[7].text = value[7] < 0 ? $"{PlayerPrefs.GetInt("Essense_H")} - {value[7]}" : $"{PlayerPrefs.GetInt("Essense_H")} + {value[7]}";
            essense[8].text = value[8] < 0 ? $"{PlayerPrefs.GetInt("Essense_I")} - {value[8]}" : $"{PlayerPrefs.GetInt("Essense_I")} + {value[8]}";

        }
    }

    public void OnSelectSummon()
    {
        SummonScrollPick.SetActive(true);
    }
    
    //図鑑No
    public void OnSelectSummonMonster(int no)
    {
        
        if (no == -1) return;

        Monster monster = SelectMonster(no);
        
        SummonNo = no;
        SummonMonster.sprite = monster.sprite;

        if (monster.essense.Count != 9) EssenseUpdate();
        else EssenseUpdate(false,monster.essense);
    }

    //召喚を行う
    public void OnLetSummon()
    {   
        //召喚できるか判定
        //インベントリの空き判定
        //アニメーション
        //エッセンスを減らす
        //インベントリに増やす
    }

    //ボタンどっちが押されたか
    public void OnSelectMatch(int place)
    {
        MatchInventoryPick.SetActive(true);
        MatchInventoryPick.GetComponent<InventoryPick>().place = place;
    }

    //場所、インベントリNo(0~110)
    public void OnSelectMatchMonster(int place,int no)
    {
        Debug.Log(place + " " + no);
        
        Monster monster = SelectMonster(no);

        if (monster.no == 0) return;


        if (place == 0)
        {   
            if(MatchNo2 == no)
            {
                MatchNo2 = MatchNo1;
                MatchMonsterRight.sprite = MatchMonsterLeft.sprite;
            }
            MatchNo1 = no;
            MatchMonsterLeft.sprite = monster.sprite;
        }
        else
        {
            if (MatchNo1 == no)
            {
                MatchNo1 = MatchNo2;
                MatchMonsterLeft.sprite = MatchMonsterRight.sprite;
            }
            MatchNo2 = no;
            MatchMonsterRight.sprite = monster.sprite;
        }

        //合成可能か判定
        FindMonsterMatching();
    }

    //合成を行う
    public void OnLetMatch()
    {
        //合成できるか判定        
        //アニメーション
        //モンスター1,2をインベントリから消去
        //インベントリに増やす
    }

    public void OnSelectEvolve()
    {
        EvolveInventoryPick.SetActive(true);
    }

    //インベントリNo(0~110)
    public void OnSelectEvolveMonster(int no)
    {
        Debug.Log(no);
        Monster monster = SelectMonster(no);

        if (monster.no == 0) return;

        EvolveNo = no;
        EvolveMonster.sprite = monster.sprite;

        EvolveMonsterAfter.sprite = monster.sprite;
    }

    //進化を行う
    public void OnLetEvolve()
    {
        //進化できるか判定（3体いるか、ランク3じゃないか判定）
        //アニメーション
        //指定したインベントリ以外のモンスターを2体消去
        //指定したインベントリのランクを増やす
    }

    public void OnSelectDelete()
    {
        
        DeleteInventoryPick.SetActive(true);
    }

    //インベントリNo(0~110)
    public void OnSelectDeleteMonster(int no)
    {
        Debug.Log(no);
        if (no == -1) return;

        Monster monster = SelectMonster(no);

        if (monster.no == 0) return;

        DeleteNo = no;
        DeleteMonster.sprite = monster.sprite;

        if (monster.essense.Count != 9) EssenseUpdate();
        else EssenseUpdate(true,monster.essense);
    }

    //分解を行う
    public void OnLetDelete()
    {
        //削除できるか判定
        //アニメーション
        //インベントリから指定したモンスターを消去
        //エッセンスを増加
    }

    private Monster SelectMonster(int no)
    {
        if (no < 100)
        {
            return DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + no));
        }
        else if (no < 103)
        {
            return DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (no - 100)));
        }
        else if (no < 106)
        {
            return DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (no - 103)));
        }
        else
        {
            return DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (no - 106)));
        }

    }

    private void FindMonsterMatching()
    {
        if (PlayerPrefs.GetInt($"{MatchNo1}") != 0 && PlayerPrefs.GetInt($"{MatchNo2}") != 0)
        {
            
        }
    }
}
