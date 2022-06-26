using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Monster
{
    public Elf(int _rank)
    {
        name = "エルフ";
        description = "耳の尖った亜人族。平和を好むが、村を荒らすものには容赦しない。";
        rank = _rank;
        no = 6000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/elf");

        maxHp = 65;
        maxMana = 70;
        baseAtk = 21;
        baseDef = 0;
        baseMag = 29;
        baseRes = 0;
        baseSpd = 31;
        skill = new PoisonShot(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
