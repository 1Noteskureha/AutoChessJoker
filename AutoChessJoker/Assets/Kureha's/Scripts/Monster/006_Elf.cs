using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Monster
{
    public Elf(int _rank)
    {
        name = "�G���t";
        description = "���̐�������l���B���a���D�ނ��A�����r�炷���̂ɂ͗e�͂��Ȃ��B";
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
