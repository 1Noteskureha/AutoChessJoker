using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    public string name;
    public string description;

    public abstract void Activate();
}

public class Poison : Effect
{
    public int target;
    public int value;

    public Poison(int _target,int _value)
    {
        name = "毒";
        description = "毒を与える。毎ターンの初めに値のダメージを与える。";

        target = _target;
        value = _value;
    }

    public override void Activate()
    {

    }

    public void Excute()
    {

    }
}

public class Betobeto : Effect
{
    public int target;
    public int value;

    public Betobeto(int _target, int _value)
    {
        name = "べとべと";
        description = "べとべとの状態。素早さが低下する";
    }

    public override void Activate()
    {
        BattleController.Instance.enemyField[target].spd -= value;
    }
}