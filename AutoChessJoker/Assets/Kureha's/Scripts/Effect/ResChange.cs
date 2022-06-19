using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResChange : Effect
{
    public ResChange(bool _ally, int _target, int _value)
    {
        name = "’ïR—Íã¸";
        description = "’ïR—Í‚ª(" + _value + ")‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].res += value;
            if (BattleController.Instance.allyField[target].res < 0)
            {
                BattleController.Instance.allyField[target].res = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].res += value;
            if (BattleController.Instance.enemyField[target].res < 0)
            {
                BattleController.Instance.enemyField[target].res = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

    }

    public new void addActivate(int _value)
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].res += _value;
            if (BattleController.Instance.allyField[target].res < 0)
            {
                BattleController.Instance.allyField[target].res = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].res += _value;
            if (BattleController.Instance.enemyField[target].res < 0)
            {
                BattleController.Instance.enemyField[target].res = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

        value += _value;
    }
}
