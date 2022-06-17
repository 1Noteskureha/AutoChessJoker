using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monster
{
    public Dragon(int _rank)
    {
        name = "ƒhƒ‰ƒSƒ“";
        description = "¬•¿‚Èƒhƒ‰ƒSƒ“B‹ó‚ğ”ò‚Ô‚±‚Æ‚Í‚Å‚«‚È‚¢";
        rank = _rank;
        no = 5000;

        //Debug.Log(no);

        symbol.Add(new Sky());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/dragon");

        maxHp = 64;
        maxMana = 90;
        baseAtk = 27;
        baseDef = 3;
        baseMag = 33;
        baseRes = 3;
        baseSpd = 22;
        skill = new Kamitsuki(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
