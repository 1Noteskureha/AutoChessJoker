using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AtkΟ»
public class AtkChange : Effect
{
    public AtkChange(bool _ally, int _target, int _value)
    {
        name = "UΝγΈ";
        description = "UΝͺ(" + _value + ")¦ι";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].atk += value;
            if (BattleController.Instance.allyField[target].atk < 0)
            {
                BattleController.Instance.allyField[target].atk = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].atk += value;
            if (BattleController.Instance.enemyField[target].atk < 0)
            {
                BattleController.Instance.enemyField[target].atk = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

    }

    public new void addActivate(int _value)
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].atk += _value;
            if (BattleController.Instance.allyField[target].atk < 0)
            {
                BattleController.Instance.allyField[target].atk = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].atk += _value;
            if (BattleController.Instance.enemyField[target].atk < 0)
            {
                BattleController.Instance.enemyField[target].atk = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

        value += _value;
    }
}
