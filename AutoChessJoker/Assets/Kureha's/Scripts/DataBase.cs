using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{
    public static Dictionary<int, string> noToName = new Dictionary<int, string>();
    //public static Dictionary<int, Stage> StageName = new Dictionary<int, Stage>();
    public static Dictionary<int, Monster> noToMonster = new Dictionary<int, Monster>();

    public static void Init()
    {   
        //noToName
        noToName.Add(1000,"ƒXƒ‰ƒCƒ€"); 

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
            case 1001:
                return new Slime(2);
            case 1002:
                return new Slime(3);
            case 2000:
                return new Goblin(1);
            case 2001:
                return new Goblin(2);
            case 2002:
                return new Goblin(3);
        }

        return new Blank();
    }
}
