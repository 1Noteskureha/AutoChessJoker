using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalSlime : Monster
{
    public MagicalSlime(int _rank)
    {
        name = "魔道スライム";
        description = "魔素の濃い場所で生まれたどろどろの粘液状の生物。";
        rank = _rank;
        no = 3000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/magicalSlime");

        maxHp = 24;
        maxMana = 100;
        baseAtk = 8;
        baseDef = 0;
        baseMag = 41;
        baseRes = 6;
        baseSpd = 29;
        skill = new Fire(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
