using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinThief : Monster
{
    public GoblinThief(int _rank)
    {
        name = "�S�u�����V�[�t";
        description = "���^�̈��l���B�l�Ԃ�d������H����D���V�G�B";
        rank = _rank;
        no = 17000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/goblinThief");

        maxHp = 27;
        maxMana = 50;
        baseAtk = 17;
        baseDef = 0;
        baseMag = 16;
        baseRes = 0;
        baseSpd = 51;
        skill = new Huiuchi(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
