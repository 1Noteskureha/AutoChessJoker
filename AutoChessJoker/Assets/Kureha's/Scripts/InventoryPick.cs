using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPick : MonoBehaviour
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

    int page = 1;

    //
    [SerializeField]
    private int type;

    //通常0 Matchの際は0か1
    public int place = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);

        inventory.AddRange(field);

        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i] = inventory[i].transform.GetChild(0).transform.GetChild(0).gameObject;
            inventory[i].GetComponent<DragAndDrop>().Init(i);
        }

        InfomationUpdate(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInventoryPrevious()
    {
        if (page == 1) return;

        page--;
        for (int i = 0; i < 4; i++)
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

    public void OnSelect(int no)
    {
        switch (type)
        {
            case 0:
                Home_Summon.Instance.OnSelectMatchMonster(place,no);
                break;
            case 1:
                Home_Summon.Instance.OnSelectEvolveMonster(no);
                break;
            case 2:
                Home_Summon.Instance.OnSelectDeleteMonster(no);
                break;
        }
        
        this.gameObject.SetActive(false);
    }

    public void InfomationUpdate(int no)
    {
        if (no == 0)
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
        for (int i = 0; i < symbolStatus.Count; i++)
        {
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

    private void OnEnable()
    {
        HomeController.Instance.TabButtonDisplay(false);
    }

    public void OnExit()
    {
        HomeController.Instance.TabButtonDisplay(true);
        this.gameObject.SetActive(false);
    }
}
