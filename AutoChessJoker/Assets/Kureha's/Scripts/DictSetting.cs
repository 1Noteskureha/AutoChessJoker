using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DictSetting : MonoBehaviour
{
    //情報
    [SerializeField]
    private Image iconSprite;
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private TMP_Text description2;
    [SerializeField]
    private List<Image> symbolSprite;

    //プレイヤー情報
    [SerializeField]
    private TMP_Text playerDescription;

    //タブ
    [SerializeField]
    private GameObject monsterTab;
    [SerializeField]
    private GameObject symbolTab;
    [SerializeField]
    private GameObject glossaryTab;

    //モンスター
    [SerializeField]
    private GameObject monsterSample;
    [SerializeField]
    private Transform monsterContent;
    private List<GameObject> monsterList;

    //シンボル
    [SerializeField]
    private GameObject symbolSample;
    [SerializeField]
    private Transform symbolContent;
    private List<GameObject> symbolList;

    //用語
    [SerializeField]
    private GameObject glossarySample;
    [SerializeField]
    private Transform glossaryContent;
    private List<GameObject> glossaryList;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo();
        TabSetting();
        OnMonsterTab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Todo
    private void PlayerInfo()
    {
        playerDescription.text =
            "プレイヤー名:仮の名前\n" +
            "今まで味方にしたモンスター数:0体\n" +
            "今まで倒した敵モンスター:10000体\n" +
            "合成回数:6000回\n";
    }

    public void OnMonsterTab()
    {
        monsterTab.SetActive(true);
        symbolTab.SetActive(false);
        glossaryTab.SetActive(false);

        

        InfomationUpdate();
    }
    public void OnSymbolTab()
    {
        monsterTab.SetActive(false);
        symbolTab.SetActive(true);
        glossaryTab.SetActive(false);

        InfomationUpdate();
    }

    public void OnGlossaryTab()
    {
        monsterTab.SetActive(false);
        symbolTab.SetActive(false);
        glossaryTab.SetActive(true);

        InfomationUpdate();
    }

    private void TabSetting()
    {
        monsterList = new List<GameObject>();
        symbolList = new List<GameObject>();
        glossaryList = new List<GameObject>();

        for (int i = 0; i < 2; i++)
        {
            int no = (i + 1) * 1000;
            monsterList.Add(Instantiate(monsterSample, monsterContent));
            monsterList[i].GetComponent<Dict_Monster>().Init(this,no);
        }

        for (int i = 0; i < 1; i++)
        {
            int no = i + 1;
            symbolList.Add(Instantiate(symbolSample, symbolContent));
            symbolList[i].GetComponent<Dict_Symbol>().Init(this, no);
        }

        for (int i = 0; i < 1; i++)
        {
            int no = i + 1;
            glossaryList.Add(Instantiate(glossarySample, glossaryContent));
            glossaryList[i].GetComponent<Dict_Glossary>().Init(this, no);
        }
    }

    public void InfomationUpdate(Sprite sp,string left,string right,List<Sprite> symbol)
    {
        iconSprite.sprite = sp;
        description.text = left;
        description2.text = right;

        for(int i = 0; i < symbol.Count; i++)
        {
            if(i > symbol.Count)
            {
                symbolSprite[i].sprite = Resources.Load<Sprite>("blank");
            }
            else
            {
                symbolSprite[i].sprite = symbol[i];
            }
        }
    }

    public void InfomationUpdate()
    {
        InfomationUpdate(null, "", "", new List<Sprite>());
    }

    public void OnExit()
    {   

        this.gameObject.SetActive(false);
    }
}
