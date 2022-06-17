using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Monster
{
    public Bat(int _rank)
    {
        name = "�o�b�g";
        description = "�H�炢���A�ɏZ�܂��l�̌����z�������B";
        rank = _rank;
        no = 7000;

        //Debug.Log(no);

        symbol.Add(new Sky());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/bat");

        maxHp = 14;
        maxMana = 40;
        baseAtk = 15;
        baseDef = 0;
        baseMag = 13;
        baseRes = 0;
        baseSpd = 34;
        skill = new BloodSteal(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
