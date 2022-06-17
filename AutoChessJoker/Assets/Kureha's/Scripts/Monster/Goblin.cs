using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    public Goblin(int _rank)
    {
        name = "ゴブリン";
        description = "小型の亜人族。いたずらが大好き。";
        rank = _rank;
        no = 2000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/goblin");

        maxHp = 28;
        maxMana = 50;
        baseAtk = 14;
        baseDef = 0;
        baseMag = 8;
        baseRes = 0;
        baseSpd = 34;
        skill = new Ishitsubute(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
