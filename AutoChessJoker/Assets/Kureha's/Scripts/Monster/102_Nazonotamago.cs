using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nazonotamago : Monster
{
    public Nazonotamago(int _rank)
    {
        name = "なぞのたまご";
        description = "なぞのたまご。殻が硬くなっている";
        rank = _rank;
        no = 102000;

        //Debug.Log(no);

        symbol.Add(new Beast());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/nazonotamago");

        maxHp = 30;
        maxMana = 80;
        baseAtk = 4;
        baseDef = 10;
        baseMag = 5;
        baseRes = 10;
        baseSpd = 3;
        skill = new Jibaku(rank);
        essense = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Init();
    }
}
