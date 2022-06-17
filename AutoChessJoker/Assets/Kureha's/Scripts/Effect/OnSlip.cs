using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSlip : Effect
{
    public OnSlip(bool _ally, int _target, int _value)
    {
        name = "スリップ";
        description = "転倒している。次の行動ができない。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].stan = true;
        }
        else
        {
            BattleController.Instance.allyField[target].stan = false;
        }

        BattleController.Instance.allyField[target].deleteTurnFirst(this);
    }
}
