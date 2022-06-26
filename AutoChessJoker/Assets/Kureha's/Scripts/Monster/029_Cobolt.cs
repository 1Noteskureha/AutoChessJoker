using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�R�{���g
public class Cobolt : Monster
{
    public Cobolt(int _rank)
    {
        name = "�R�{���g";
        description = "�Q��ŕ�炷�����ȏb�B�x���S������";
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
