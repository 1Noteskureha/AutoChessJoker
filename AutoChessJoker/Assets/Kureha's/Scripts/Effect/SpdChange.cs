using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//‘f‘‚³•ÏX
public class SpdChange : Effect
{
    public SpdChange(bool _ally, int _target, int _value)
    {
        name = "‘f‘‚³ã¸";
        description = "‘f‘‚³‚ª(" + _value + ")‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].spd += value;
            if (BattleController.Instance.allyField[target].spd < 0)
            {
                BattleController.Instance.allyField[target].spd = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].spd += value;
            if (BattleController.Instance.enemyField[target].spd < 0)
            {
                BattleController.Instance.enemyField[target].spd = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

    }

    public new void addActivate(int _value)
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].spd += _value;
            if (BattleController.Instance.allyField[target].spd < 0)
            {
                BattleController.Instance.allyField[target].spd = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].spd += _value;
            if (BattleController.Instance.enemyField[target].spd < 0)
            {
                BattleController.Instance.enemyField[target].spd = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

        value += _value;
    }
}
