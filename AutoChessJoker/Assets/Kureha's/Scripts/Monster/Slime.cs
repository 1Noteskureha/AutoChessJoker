using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スライム
public class Slime : Monster
{
    public Slime(int _rank)
    {
        name = "スライム";
        description = "どろどろの粘液状の生物。";
        rank = _rank;
        no = 1000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/slime");

        maxHp = 26;
        maxMana = 100;
        baseAtk = 10;
        baseDef = 0;
        baseMag = 25;
        baseRes = 1;
        baseSpd = 29;
        skill = new Nenneki(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}