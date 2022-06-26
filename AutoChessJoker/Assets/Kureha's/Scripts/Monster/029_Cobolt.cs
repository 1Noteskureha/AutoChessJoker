using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//コボルト
public class Cobolt : Monster
{
    public Cobolt(int _rank)
    {
        name = "コボルト";
        description = "群れで暮らす小柄な獣。警戒心が強い";
        rank = _rank;
        no = 29000;

        //Debug.Log(no);

        symbol.Add(new Beast());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/cobolt");

        maxHp = 44;
        maxMana = 50;
        baseAtk = 16;
        baseDef = 0;
        baseMag = 14;
        baseRes = 0;
        baseSpd = 22;
        skill = new Kamitsuki(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
