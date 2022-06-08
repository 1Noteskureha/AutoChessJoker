using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dict_Monster : MonoBehaviour
{
    private DictSetting parent;
    private int no;
    private int type;

    [SerializeField]
    private TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(DictSetting ds,int _no)
    {
        parent = ds;
        no = _no;

        type = PlayerPrefs.GetInt("Dict_Unlock" + no);


        if (type == 0)
        {
            text.text = "？？？？？";
        }
        else
        {
            text.text = DataBase.Bt_noToMonster(no).name;
        }
    }

    public void Display()
    {
        Monster monster = DataBase.Bt_noToMonster(no);

        string description1;
        if (type == 2)
        {

            description1 =
                $"名前: {monster.name}\n" +
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

        }
        else
        {
            description1 =
            $"名前:？？？？？\n" +
            $"シンボル: \n" +
            $"最大HP:？？？？？\n" +
            $"最大マナ:？？？？？\n" +
            $"攻撃力:？？？？？\n" +
            $"防御力:？？？？？\n" +
            $"魔力:？？？？？\n" +
            $"抵抗力:？？？？？\n" +
            $"素早さ:？？？？？\n" +
            $"スキル:？？？？？\n" +
            $"？？？？？\n" +
            $"\n" +
            $"？？？？？";
        }
        string description2 =
            "組み合わせ例";

        List<Sprite> symbols = new List<Sprite>();

        for (int i = 0; i < monster.symbol.Count; i++) symbols.Add(monster.symbol[i].sprite);

        parent.InfomationUpdate(monster.sprite,description1,description2, symbols);
    }
}
