using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X���C��
public class Slime : Monster
{
    public Slime(int _rank)
    {
        name = "�X���C��";
        description = "�ǂ�ǂ�̔S�t��̐����B";
        rank = _rank;
        no = 1000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/slime");

        maxHp = 26;
        maxMana = 100;
        baseAtk = 10;
        baseDef = 0;
        baseMag = 25;
        baseRes = 1;
        baseSpd = 29;
        skill = new Nenneki(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}