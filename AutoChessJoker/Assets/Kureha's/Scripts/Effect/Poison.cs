using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Effect
{
    public bool ally;
    public int target;
    public int value;

    public Poison(bool _ally, int _target, int _value)
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
