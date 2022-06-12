using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ScrollMonster : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private TMP_Text text;

    private ScrollPick parent;
    private int no;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(ScrollPick sp,int _no)
    {
        parent = sp;
        no = _no;

        if (PlayerPrefs.GetInt("Dict_Unlock" + no) == 2)
        {
            text.text = DataBase.Bt_noToMonster(no).name;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Display();
    }

    public void Display()
    {
        Monster monster = DataBase.Bt_noToMonster(no);

        string description =
                $"���O: {monster.name}\n" +
                $"�V���{��: \n" +
                $"�ő�HP: {monster.maxHp}\n" +
                $"�ő�}�i: {monster.maxMana}\n" +
                $"�U����: {monster.baseAtk}\n" +
                $"�h���: {monster.baseDef}\n" +
                $"����: {monster.baseMag}\n" +
                $"��R��: {monster.baseRes}\n" +
                $"�f����: {monster.baseSpd}\n" +
                $"�X�L��: {monster.skill.name}\n" +
                $"{monster.skill.description}\n" +
                $"\n" +
                $"{monster.description}";

        List<Sprite> symbols = new List<Sprite>();

        for (int i = 0; i < monster.symbol.Count; i++) symbols.Add(monster.symbol[i].sprite);

        parent.InfomationUpdate(monster.sprite, description, symbols);
    }

    public void OnSelect()
    {
        parent.OnSelect(no);
    }
}
