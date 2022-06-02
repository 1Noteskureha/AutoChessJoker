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
        noToName.Add(1000,"スライム");

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
        StageName.Add(1,new Stage("始まりの草原","初心者向けダンジョン。草属性の敵が多く出現！", essense,monster));

            

        //noToMonster
        noToMonster.Add(1000,new Slime(1));
        noToMonster.Add(1001,new Slime(2));
        noToMonster.Add(1002,new Slime(3));
    }


}
