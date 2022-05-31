using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string name;
    public List<int> essense;
    //public Sprite sprite;
    public string description;

    public Stage(string _name,string _description,List<int> _essense)
    {
        name = _name;
        description = _description;
        essense = _essense;
    }
}

public static class DataBase
{
    public static Dictionary<int, string> noToName = new Dictionary<int, string>();
    public static Dictionary<int, Stage> StageName = new Dictionary<int, Stage>();

    public static void Init()
    {
        noToName.Add(1000,"スライム");

        StageName.Add(1,new Stage("始まりの草原","初心者向けダンジョン。草属性の敵が多く出現！", new List<int>() {5,0,0,0,0,0,0,0}));
    }
}
