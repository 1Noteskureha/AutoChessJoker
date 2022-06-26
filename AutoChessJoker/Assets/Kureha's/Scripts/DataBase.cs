using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{
    //public static Dictionary<int, string> noToName = new Dictionary<int, string>();
    //public static Dictionary<int, Stage> StageName = new Dictionary<int, Stage>();
    //public static Dictionary<int, Monster> noToMonster = new Dictionary<int, Monster>();

    public static void Init()
    {   
        //noToName
        //noToName.Add(1000,"ÉXÉâÉCÉÄ"); 

        //noToMonster
        //noToMonster.Add(1000,new Slime(1));
        //noToMonster.Add(1001,new Slime(2));
        //noToMonster.Add(1002,new Slime(3));
    }

    public static Symbol DictSymbol(int value)
    {
        switch (value)
        {
            case 1:
                return new Glass();
            case 2:
                return new Ground();
            case 3:
                return new Beast();
            case 4:
                return new symbolFire();
            case 5:
                return new Aqua();
            case 6:
                return new Electric();
            case 7:
                return new Sky();
            case 8:
                return new Death();
            case 9:
                return new Holy();
        }

        return null;
    }

    public static string DictYougo(int value)
    {
        switch (value)
        {
            case 1:
                return "1ÉRÉÅ";
        }

        return "";
    }

    public static Monster DictMatching(int monsterNo1,int monsterNo2)
    {
        return new Blank();
    }

    public static Monster Bt_noToMonster(int value)
    {
        int rank = value % 1000 + 1;
        value = value - rank + 1;
        for (int i = 0; i < 3; i++)
        {
            switch (value)
            {
                case 1000:
                    return new Slime(rank);
                case 2000:
                    return new Fairy(rank);
                case 3000:
                    return new MagicalSlime(rank);
                case 4000:
                //return new SlimeMonster(some);
                case 5000:
                //return new GreenMonster(some):
                case 6000:
                    return new Elf(rank);
                case 7000:
                //return new TreeFork(rank);
                case 8000:
                    return new Kodama(rank);
                case 9000:
                    //return new KirikabuObake(rank);
                case 10000:
                    //return new Snake(rank);
                case 11000:
                    return new Dragon(rank);
                case 12000:
                    //return new Dryad(rank);
                case 13000:
                    //return new Sylpheed(rank);
                case 14000:
                    //return new WorldTree(rank);
                case 15000:
                    return new Goblin(rank);
                case 16000:
                    return new GoblinAxe(rank);
                case 17000:
                    return new GoblinThief(rank);
                case 18000:
                    //return new GoblinRoad(rank);
                case 19000:
                    //return new RockMonster(rank);
                case 20000:
                    //return new Golem(rank);
                case 21000:
                    //return new DualSerpent(rank);
                case 22000:
                    return new Bat(rank);
                case 23000:
                    //return new Dracula(rank);
                case 24000:
                    //return new Yamatanoorochi(rank);
                case 25000:
                    //return new Scorpion(rank);
                case 26000:
                    //return new Monolis(rank);
                case 27000:
                    //return new RockDragon(rank);
                case 28000:
                //return new CrystalDragon(rank);

                default:
                    return new Blank();

            }
        }

        return new Blank();
    }
}
