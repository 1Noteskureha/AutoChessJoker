using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDragon : Monster
{
    public FlyDragon(int _rank)
    {
        name = "��";
        description = "����ԗ�����ɓ��ꉊ��f���Ĕ�щ��h���S���B";
        rank = _rank;
        no = 83000;

        //Debug.Log(no);

        symbol.Add(new Sky());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/flyDragon");

        maxHp = 124;
        maxMana = 150;
        baseAtk = 35;
        baseDef = 4;
        baseMag = 38;
        baseRes = 4;
        baseSpd = 28;
        skill = new FireBreath(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
