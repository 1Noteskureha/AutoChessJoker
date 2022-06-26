using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalSlime : Monster
{
    public MagicalSlime(int _rank)
    {
        name = "–‚“¹ƒXƒ‰ƒCƒ€";
        description = "–‚‘f‚Ì”Z‚¢êŠ‚Å¶‚Ü‚ê‚½‚Ç‚ë‚Ç‚ë‚Ì”S‰tó‚Ì¶•¨B";
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
