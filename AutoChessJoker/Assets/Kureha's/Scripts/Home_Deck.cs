using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Home_Deck : SingletonMonoBehaviour<Home_Deck>
{
    [SerializeField]
    private List<GameObject> inventoryParent;
    [SerializeField]
    private TMP_Text display;

    [SerializeField]
    private List<GameObject> inventory;
    [SerializeField]
    private List<GameObject> field;

    //ステータス
    [SerializeField]
    private Image monsterImage;
    [SerializeField]
    private TMP_Text status;
    [SerializeField]
    private List<Image> symbolStatus;

    //シンボル発動
    [SerializeField]
    private List<Image> activeSymbol;
    [SerializeField]
    private List<TMP_Text> activeSymbolText;

    int page = 1;
    bool inited = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);

        inventory.AddRange(field);

        for(int i = 0; i < inventory.Count; i++)
        {
            inventory[i] = inventory[i].transform.GetChild(0).transform.GetChild(0).gameObject;
            inventory[i].GetComponent<DragAndDrop>().Init(i);
        }

        InfomationUpdate(0);
        inited = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInventoryPrevious()
    {
        if (page == 1) return;

        page--;
        for(int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);
        display.text = $"{page}/4";
    }

    public void OnInventoryNext()
    {
        Debug.Log(page);
        if (page == 4) return;

        page++;
        for (int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);
        display.text = $"{page}/4";
    }

    public void InventorySwap(int a,int b)
    {
        int tmp,tmp2;
        if (a < 100) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (a + 1))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (a + 1))).rank - 1;
        else if(a < 103) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (a + 1 - 100))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (a + 1 - 100))).rank - 1;
        else if(a < 106) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (a + 1 - 103))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (a + 1 - 103))).rank - 1;
        else tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (a + 1 - 106))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (a + 1 - 106))).rank - 1;

        if (b < 100) tmp2 = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (b + 1))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (b + 1))).rank - 1;
        else if (b < 103) tmp2 = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (b + 1 - 100))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (b + 1 - 100))).rank - 1;
        else if (b < 106) tmp2 = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (b + 1 - 103))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (b + 1 - 103))).rank - 1;
        else tmp2 = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (b + 1 - 106))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (b + 1 - 106))).rank - 1;

        if (a < 100) PlayerPrefs.SetInt("Inventory_Monster" + (a + 1), tmp2);
        else if (a < 103) PlayerPrefs.SetInt("Bt_Front" + (a + 1 - 100), tmp2);
        else if (a < 106) PlayerPrefs.SetInt("Bt_Back" + (a + 1 - 103), tmp2);
        else PlayerPrefs.SetInt("Bt_Support" + (a + 1 - 106),tmp2);

        if (b < 100) PlayerPrefs.SetInt("Inventory_Monster" + (b + 1), tmp);
        else if (b < 103) PlayerPrefs.SetInt("Bt_Front" + (b + 1 - 100), tmp);
        else if (b < 106) PlayerPrefs.SetInt("Bt_Back" + (b + 1 - 103), tmp);
        else PlayerPrefs.SetInt("Bt_Support" + (b + 1 - 106), tmp);

        inventory[a].GetComponent<DragAndDrop>().SetInfo();
        inventory[b].GetComponent<DragAndDrop>().SetInfo();

    }

    public void InfomationUpdate(int no)
    {   
        if(no == 0)
        {
            status.text = "";
            monsterImage.sprite = Resources.Load<Sprite>("blank");
            for (int i = 0; i < symbolStatus.Count; i++)
            {
                symbolStatus[i].sprite = Resources.Load<Sprite>("blank");
            }

            return;
        }        
        Monster monster = DataBase.Bt_noToMonster(no);

        status.text =
            $"名前: {monster.name}\n" +
            $"ランク: {monster.rank}\n" +
            $"シンボル: \n" +
            $"最大HP: {monster.maxHp}\n" +
            $"最大マナ: {monster.maxMana}\n" +
            $"攻撃力: {monster.baseAtk}\n" +
            $"防御力: {monster.baseDef}\n" +
            $"魔力: {monster.baseMag}\n" +
            $"抵抗力: {monster.baseRes}\n" +
            $"素早さ: {monster.baseSpd}\n" +
            $"スキル: {monster.skill.name}\n" +
            $"{monster.skill.description}\n" +
            $"\n" +
            $"{monster.description}";

        monsterImage.sprite = monster.sprite;
        for (int i = 0; i <symbolStatus.Count;i++) {
            if (i < monster.symbol.Count)
            {
                symbolStatus[i].sprite = monster.symbol[i].sprite;
            }
            else
            {
                symbolStatus[i].sprite = Resources.Load<Sprite>("blank");
            }
        }
    }

    public void OnEnable()
    {
        if (inited == false) return;
        for (int i = 0; i < inventory.Count; i++)
        {            
            inventory[i].GetComponent<DragAndDrop>().Init(i);
        }
    }
}
