using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolf : Monster
{
    public WereWolf(int _rank)
    {
        name = "ワーウルフ";
        description = "人の体格を持つ狼。人狼とも。";
        rank = _rank;
        no = 34000;

        //Debug.Log(no);

        symbol.Add(new Beast());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/wereWolf");

        maxHp = 94;
        maxMana = 50;
        baseAtk = 21;
        baseDef = 0;
        baseMag = 25;
        baseRes = 0;
        baseSpd = 19;
        skill = new Kamitsuki(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
