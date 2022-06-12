using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPChange : Effect
{
    public HPChange(bool _ally, int _target, int _value)
    {
        name = "HPè„è∏";
        description = "HPÇ™(" + _value + ")ëùÇ¶ÇÈ";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].maxHp += value;
            BattleController.Instance.allyField[target].hp += value;
        }
        else
        {
            BattleController.Instance.enemyField[target].maxHp += value;
            BattleController.Instance.enemyField[target].hp += value;
        }

    }
}
