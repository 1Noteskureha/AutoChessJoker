using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kodama : Monster
{
    public Kodama(int _rank)
    {
        name = "‚±‚¾‚Ü";
        description = "X‚Ì—d¸BX‚Å–À‚Á‚Ä‚¢‚éŒ»‚ê‚é‚Æ‚³‚ê‚éB";
        rank = _rank;
        no = 8000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/kodama");

        maxHp = 30;
        maxMana = 56;
        baseAtk = 9;
        baseDef = 0;
        baseMag = 25;
        baseRes = 3;
        baseSpd = 18;
        skill = new Heal(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
