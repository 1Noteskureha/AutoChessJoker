using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAxe : Monster
{
    public GoblinAxe(int _rank)
    {
        name = "ゴブリンアクス";
        description = "小型の亜人族。オノを持つ戦闘班。";
        rank = _rank;
        no = 16000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/goblinAxe");

        maxHp = 35;
        maxMana = 50;
        baseAtk = 19;
        baseDef = 0;
        baseMag = 11;
        baseRes = 0;
        baseSpd = 24;
        skill = new Kyogiri(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
