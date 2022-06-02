using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{
    public static Dictionary<int, string> noToName = new Dictionary<int, string>();
    public static Dictionary<int, Stage> StageName = new Dictionary<int, Stage>();
    public static Dictionary<int, Monster> noToMonster = new Dictionary<int, Monster>();

    public static void Init()
    {   
        //noToName
        noToName.Add(1000,"�X���C��");

        List<List<int>> essense = new List<List<int>>()
        {
            new List<int>() {5,0,0,0,0,0,0,0,0},
            new List<int>() {10,0,0,0,0,0,0,0,0},
            new List<int>() {10,0,0,0,0,0,0,0,0},
            new List<int>() {50,5,5,0,0,0,0,0,0},
        };

        List<List<Monster>> monster = new List<List<Monster>>()
        {
            new List<Monster>() {new Blank(),new Slime(1), new Blank(), new Blank(), new Blank(), new Blank() },
            new List<Monster>() { new Slime(1), new Slime(1), new Slime(1), new Blank(), new Blank(), new Blank() },
            new List<Monster>() { new Slime(1), new Slime(1), new Blank(), new Slime(1), new Blank(), new Slime(1) },
            new List<Monster>() { new Slime(1), new Slime(2), new Slime(1), new Slime(1), new Slime(1), new Slime(1) },
        };

        //StageName
        StageName.Add(1,new Stage("�n�܂�̑���","���S�Ҍ����_���W�����B�������̓G�������o���I", essense,monster));

            

        //noToMonster
        noToMonster.Add(1000,new Slime(1));
        noToMonster.Add(1001,new Slime(2));
        noToMonster.Add(1002,new Slime(3));
    }

    public static Monster Bt_noToMonster(int value)
    {
        switch (value)
        {
            case 1000:
                return new Slime(1);
                break;
            case 1001:
                return new Slime(2);
                break;
            case 1002:
                return new Slime(3);
                break;
        }

        return new Blank();
    }
}
