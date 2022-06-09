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

    //Match
    [SerializeField]
    private Image MatchMonsterleft;
    [SerializeField]
    private Image MatchMonsterright;
    [SerializeField]
    private Image MatchMonsterAfter;

    //Evolve
    [SerializeField]
    private Image EvolveMonster;
    [SerializeField]
    private Image EvolveMonsterAfter;

    //Delete
    [SerializeField]
    private Image DeleteMonster;

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
    }

    public void OnMatch()
    {
        Summon.SetActive(false);
        Match.SetActive(true);
        Evolve.SetActive(false);
        Delete.SetActive(false);
    }

    public void OnEvolve()
    {
        Summon.SetActive(false);
        Match.SetActive(false);
        Evolve.SetActive(true);
        Delete.SetActive(false);
    }

    public void OnDelete()
    {
        Summon.SetActive(false);
        Match.SetActive(false);
        Evolve.SetActive(false);
        Delete.SetActive(true);
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

    public void OnSelectSummon()
    {
        SummonScrollPick.SetActive(true);
    }
    
    //�}��No
    public void OnSelectSummonMonster(int no)
    {

    }

    //�������s��
    public void OnLetSummon()
    {

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

    }

    //�������s��
    public void OnLetMatch()
    {

    }

    public void OnSelectEvolve()
    {
        EvolveInventoryPick.SetActive(true);
    }

    //�C���x���g��No(0~110)
    public void OnSelectEvolveMonster(int no)
    {

    }

    //�i�����s��
    public void OnLetEvolve()
    {

    }

    public void OnSelectDelete()
    {
        DeleteInventoryPick.SetActive(true);
    }

    //�C���x���g��No(0~110)
    public void OnSelectDeleteMonster(int no)
    {

    }

    //�������s��
    public void OnLetDelete()
    {

    }
}
