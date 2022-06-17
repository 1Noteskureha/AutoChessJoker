using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konton : Monster
{
    public Konton(int _rank)
    {
        name = "¬“×";
        description = "ˆÅ‚æ‚è¶‚Ü‚ê‚µ‚à‚ÌB¶‚Ü‚ê‚ğô‚Á‚Ä‚¢‚é";
        rank = _rank;
        no = 10000;

        //Debug.Log(no);

        symbol.Add(new Beast());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/konton");

        maxHp = 313;
        maxMana = 100;
        baseAtk = 54;
        baseDef = 8;
        baseMag = 56;
        baseRes = 16;
        baseSpd = 51;
        skill = new Darkness(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
