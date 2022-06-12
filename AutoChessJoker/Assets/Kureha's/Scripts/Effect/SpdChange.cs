using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�f�����ύX
public class SpdChange : Effect
{
    public SpdChange(bool _ally, int _target, int _value)
    {
        name = "�f�����㏸";
        description = "�f������(" + _value + ")������";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].spd += value;
            if (BattleController.Instance.allyField[target].spd < 0) BattleController.Instance.allyField[target].spd = 0;
        }
        else
        {
            BattleController.Instance.enemyField[target].spd -= value;
            if (BattleController.Instance.enemyField[target].spd < 0) BattleController.Instance.enemyField[target].spd = 0;
        }

    }
}
