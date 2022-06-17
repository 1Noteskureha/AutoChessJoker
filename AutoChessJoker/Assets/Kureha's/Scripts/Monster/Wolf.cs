using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Monster
{
    public Wolf(int _rank)
    {
        name = "ƒEƒ‹ƒt";
        description = "X‚âáŒ´‚ÉZ‚Ü‚¤ëlB‰s‚¢‰å‚ğ‚ÂB";
        rank = _rank;
        no = 11000;

        //Debug.Log(no);

        symbol.Add(new Beast());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/wolf");

        maxHp = 104;
        maxMana = 60;
        baseAtk = 23;
        baseDef = 0;
        baseMag = 19;
        baseRes = 2;
        baseSpd = 24;
        skill = new Kamitsuki(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
