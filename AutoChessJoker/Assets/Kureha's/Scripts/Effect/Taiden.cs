using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taiden : Effect
{
    public Taiden(bool _ally, int _target, int _value)
    {
        name = "帯電";
        description = "帯電している。毎ターンの初めに麻痺を与える。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        BattleController.Instance.allyField[target].addTurnFirst(new OnParalyse(ally, target, value));
    }
}
