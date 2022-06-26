using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Monster
{
    public Fairy(int _rank)
    {
        name = "�d��";
        description = "�Â��ȐX�ɏZ�܂��d���B�������Ƃ��D�܂��A�������҂�����B";
        rank = _rank;
        no = 2000;

        //Debug.Log(no);

        symbol.Add(new Sky());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/fairy");

        maxHp = 18;
        maxMana = 90;
        baseAtk = 6;
        baseDef = 0;
        baseMag = 47;
        baseRes = 7;
        baseSpd = 35;
        skill = new Heal(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
