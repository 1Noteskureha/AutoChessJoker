using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Monster
{
    public Fairy(int _rank)
    {
        name = "妖精";
        description = "静かな森に住まう妖精。争いごとを好まず、傷ついた者を癒す。";
        rank = _rank;
        no = 2000;

        //Debug.Log(no);

        symbol.Add(new Sky());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/fairy");

        maxHp = 18;
        maxMana = 90;
        baseAtk = 6;
        baseDef = 0;
        baseMag = 47;
        baseRes = 7;
        baseSpd = 35;
        skill = new Heal(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
