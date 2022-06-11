using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Home_Summon : SingletonMonoBehaviour<Home_Summon>
{   
    //�^�u
    [SerializeField]
    private GameObject Summon;
    [SerializeField]
    private GameObject Match;
    [SerializeField]
    private GameObject Evolve;
    [SerializeField]
    private GameObject Delete;

    //�C���x���g�����̓X�N���[�����J��
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
    [SerializeField]
    private Animator summonAnim;

    private int SummonNo = -1;

    //Match
    [SerializeField]
    private Image MatchMonsterLeft;
    [SerializeField]
    private Image MatchMonsterRight;
    [SerializeField]
    private Image MatchMonsterAfter;
    [SerializeField]
    private Animator matchAnim;

    private int MatchNo1 = -1;
    private int MatchNo2 = -1;

    //Evolve
    [SerializeField]
    private Image EvolveMonster;
    [SerializeField]
    private Image EvolveMonsterAfter;
    [SerializeField]
    private Animator evolveAnim;

    private int EvolveNo = -1;

    //Delete
    [SerializeField]
    private Image DeleteMonster;
    [SerializeField]
    private Animator deleteAnim;

    private int DeleteNo = -1;

    //�G�b�Z���X�\��(����or������)
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
    
    //�}��No
    public void OnSelectSummonMonster(int no)
    {
        
        if (no == -1) return;

        Monster monster = SelectMonster(no);
        
        SummonNo = no;
        SummonMonster.sprite = monster.sprite;

        if (monster.essense.Count != 9) EssenseUpdate();
        else EssenseUpdate(false,monster.essense);
    }

    //�������s��
    public void OnLetSummon()
    {   
        Monster monster = SelectMonster(SummonNo);

        //�����ł��邩����
        if (PlayerPrefs.GetInt("Essense_A") >= monster.essense[0] &&
            PlayerPrefs.GetInt("Essense_B") >= monster.essense[1] &&
            PlayerPrefs.GetInt("Essense_C") >= monster.essense[2] &&
            PlayerPrefs.GetInt("Essense_D") >= monster.essense[3] &&
            PlayerPrefs.GetInt("Essense_E") >= monster.essense[4] &&
            PlayerPrefs.GetInt("Essense_F") >= monster.essense[5] &&
            PlayerPrefs.GetInt("Essense_G") >= monster.essense[6] &&
            PlayerPrefs.GetInt("Essense_H") >= monster.essense[7] &&
            PlayerPrefs.GetInt("Essense_I") >= monster.essense[8]
            )
        {   
            //�C���x���g���̋󂫔���
            for(int i = 0; i < 100; i++)
            {
                if(PlayerPrefs.GetInt("Inventory_Monster" + (i + 1)) == 0)
                {   
                    //�G�b�Z���X�����炷
                    PlayerPrefs.SetInt("Essense_A", PlayerPrefs.GetInt("Essense_A") - monster.essense[0]);
                    PlayerPrefs.SetInt("Essense_B", PlayerPrefs.GetInt("Essense_B") - monster.essense[1]);
                    PlayerPrefs.SetInt("Essense_C", PlayerPrefs.GetInt("Essense_C") - monster.essense[2]);
                    PlayerPrefs.SetInt("Essense_D", PlayerPrefs.GetInt("Essense_D") - monster.essense[3]);
                    PlayerPrefs.SetInt("Essense_E", PlayerPrefs.GetInt("Essense_E") - monster.essense[4]);
                    PlayerPrefs.SetInt("Essense_F", PlayerPrefs.GetInt("Essense_F") - monster.essense[5]);
                    PlayerPrefs.SetInt("Essense_G", PlayerPrefs.GetInt("Essense_G") - monster.essense[6]);
                    PlayerPrefs.SetInt("Essense_H", PlayerPrefs.GetInt("Essense_H") - monster.essense[7]);
                    PlayerPrefs.SetInt("Essense_I", PlayerPrefs.GetInt("Essense_I") - monster.essense[8]);

                    //�C���x���g���ɑ��₷
                    PlayerPrefs.SetInt("Inventory_Monster" + (i + 1),monster.no);

                    //�A�j���[�V����
                    StartCoroutine(WaitAnimation(summonAnim));

                    SummonNo = 0;
                    SummonMonster.sprite = Resources.Load<Sprite>("Monster/blank");

                    break;
                }
            }
        }
        
        
    }

    //�{�^���ǂ����������ꂽ��
    public void OnSelectMatch(int place)
    {
        MatchInventoryPick.SetActive(true);
        MatchInventoryPick.GetComponent<InventoryPick>().place = place;
    }

    //�ꏊ�A�C���x���g��No(0~110)
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

        //�����\������
        FindMonsterMatching();
    }

    //�������s��
    public void OnLetMatch()
    {
        //�����ł��邩����        
        //�A�j���[�V����
        //�����X�^�[1,2���C���x���g���������
        //�C���x���g���ɑ��₷
    }

    public void OnSelectEvolve()
    {
        EvolveInventoryPick.SetActive(true);
    }

    //�C���x���g��No(0~110)
    public void OnSelectEvolveMonster(int no)
    {
        Debug.Log(no);
        Monster monster = SelectMonster(no);

        if (monster.no == 0) return;

        EvolveNo = no;
        EvolveMonster.sprite = monster.sprite;

        EvolveMonsterAfter.sprite = monster.sprite;
    }

    //�i�����s��
    public void OnLetEvolve()
    {
        Monster monster = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + EvolveNo));

        if (monster.no != 0) return;
        int monsterCount = 1;
        int inventory1 = 0;
        int inventory2 = 0;
        //�i���ł��邩����i3�̂��邩�A�����N3����Ȃ�������j    
        if (monster.rank == 3) return;
        
        for (int i = 0; i < 100; i++) {

            if (PlayerPrefs.GetInt("Inventory_Monster" + (i + 1)) == monster.no && (i + 1) != EvolveNo && monster.rank == PlayerPrefs.GetInt("Inventory_Monster" + (i + 1))%1000 + 1)
            {
                monsterCount++;

                if(monsterCount == 2) inventory1 = i + 1;
                if(monsterCount == 3){
                    inventory2 = i + 1;

                    //�w�肵���C���x���g���ȊO�̃����X�^�[��2�̏���
                    PlayerPrefs.SetInt("Inventory_Monster" + inventory1,0);
                    PlayerPrefs.SetInt("Inventory_Monster" + inventory2,0);

                    //�w�肵���C���x���g���̃����N�𑝂₷
                    PlayerPrefs.SetInt("Inventory_Monster" + (i + 1), monster.no + monster.rank);

                    //�A�j���[�V����
                    StartCoroutine(WaitAnimation(evolveAnim));

                    EvolveNo = 0;
                    EvolveMonster.sprite = Resources.Load<Sprite>("Monster/blank");

                    EvolveMonsterAfter.sprite = Resources.Load<Sprite>("Monster/blank");
                    break;
                }
            }
        }

    }

    public void OnSelectDelete()
    {
        
        DeleteInventoryPick.SetActive(true);
    }

    //�C���x���g��No(0~110)
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

    //�������s��
    public void OnLetDelete()
    {
        Monster monster = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + DeleteNo));

        //�폜�ł��邩����
        if (PlayerPrefs.GetInt("Inventory_Monster" + DeleteNo) == 0) return;

        //�C���x���g������w�肵�������X�^�[������
        PlayerPrefs.SetInt("Inventory_Monster" + DeleteNo, 0);

        //�G�b�Z���X�𑝉�
        PlayerPrefs.SetInt("Essense_A", PlayerPrefs.GetInt("Essense_A") + monster.essense[0]);
        PlayerPrefs.SetInt("Essense_B", PlayerPrefs.GetInt("Essense_B") + monster.essense[1]);
        PlayerPrefs.SetInt("Essense_C", PlayerPrefs.GetInt("Essense_C") + monster.essense[2]);
        PlayerPrefs.SetInt("Essense_D", PlayerPrefs.GetInt("Essense_D") + monster.essense[3]);
        PlayerPrefs.SetInt("Essense_E", PlayerPrefs.GetInt("Essense_E") + monster.essense[4]);
        PlayerPrefs.SetInt("Essense_F", PlayerPrefs.GetInt("Essense_F") + monster.essense[5]);
        PlayerPrefs.SetInt("Essense_G", PlayerPrefs.GetInt("Essense_G") + monster.essense[6]);
        PlayerPrefs.SetInt("Essense_H", PlayerPrefs.GetInt("Essense_H") + monster.essense[7]);
        PlayerPrefs.SetInt("Essense_I", PlayerPrefs.GetInt("Essense_I") + monster.essense[8]);

        //�A�j���[�V����
        StartCoroutine(WaitAnimation(deleteAnim));

        DeleteNo = 0;
        DeleteMonster.sprite = Resources.Load<Sprite>("Monster/blank");
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

    private IEnumerator WaitAnimation(Animator anim)
    {
        anim.gameObject.SetActive(true);

        yield return new WaitForAnimation(anim.GetComponent<Animator>());

        anim.gameObject.SetActive(false);

        yield break;
    }
}
