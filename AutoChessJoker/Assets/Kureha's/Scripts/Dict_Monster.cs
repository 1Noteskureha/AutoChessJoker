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
            text.text = "�H�H�H�H�H";
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

        }
        else
        {
            description1 =
            $"���O:�H�H�H�H�H\n" +
            $"�V���{��: \n" +
            $"�ő�HP:�H�H�H�H�H\n" +
            $"�ő�}�i:�H�H�H�H�H\n" +
            $"�U����:�H�H�H�H�H\n" +
            $"�h���:�H�H�H�H�H\n" +
            $"����:�H�H�H�H�H\n" +
            $"��R��:�H�H�H�H�H\n" +
            $"�f����:�H�H�H�H�H\n" +
            $"�X�L��:�H�H�H�H�H\n" +
            $"�H�H�H�H�H\n" +
            $"\n" +
            $"�H�H�H�H�H";
        }
        string description2 =
            "�g�ݍ��킹��";

        List<Sprite> symbols = new List<Sprite>();

        for (int i = 0; i < monster.symbol.Count; i++) symbols.Add(monster.symbol[i].sprite);

        parent.InfomationUpdate(monster.sprite,description1,description2, symbols);
    }
}
