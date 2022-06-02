using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string name;
    public List<List<int>> essense;
    //public Sprite sprite;
    public string description;

    public List<List<Monster>> enemyFields;

    public Stage(string _name, string _description, List<List<int>> _essense,List<List<Monster>> _enemyFields)
    {
        name = _name;
        description = _description;
        essense = _essense;
        enemyFields = _enemyFields;
    }
}