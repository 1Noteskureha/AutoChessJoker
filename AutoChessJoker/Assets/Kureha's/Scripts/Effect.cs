using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    public string name;
    public string description;

    //付与時の行動
    public void Activate() { }

    //継続的な行動
    public void Excute() { }
}

public class Poison : Effect
{
    public bool ally;
    public int target;
    public int value;

    public Poison(bool _ally,int _target,int _value)
    {
        name = "毒";
        description = "毒を与える。毎ターンの初めに値のダメージを与える。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {

    }

    public new void Excute()
    {

    }
}

public class Betobeto : Effect
{
    public bool ally;
    public int target;
    public int value;

    public Betobeto(bool _ally,int _target, int _value)
    {
        name = "べとべと";
        description = "べとべとの状態。素早さが低下する";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {   
        if(ally) BattleController.Instance.enemyField[target].spd -= value;
        else BattleController.Instance.enemyField[target].spd -= value;
    }

    public new void Excute()
    {

    }
}