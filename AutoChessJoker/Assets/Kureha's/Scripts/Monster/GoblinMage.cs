using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMage : Monster
{
    public GoblinMage(int _rank)
    {
        name = "ゴブリンマージ";
        description = "小型の亜人族。魔法を扱うことのできる変異種。";
        rank = _rank;
        no = 13000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/goblinMage");

        maxHp = 26;
        maxMana = 40;
        baseAtk = 11;
        baseDef = 0;
        baseMag = 21;
        baseRes = 0;
        baseSpd = 11;
        skill = new ThunderBolt(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
