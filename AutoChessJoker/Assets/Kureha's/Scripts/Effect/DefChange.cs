using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Def•Ï‰»
public class DefChange : Effect
{
    public DefChange(bool _ally, int _target, int _value)
    {
        name = "–hŒä—Íã¸";
        description = "–hŒä—Í‚ª(" + _value + ")‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].def += value;
            if (BattleController.Instance.allyField[target].def < 0)
            {
                BattleController.Instance.allyField[target].def = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].def += value;
            if (BattleController.Instance.enemyField[target].def < 0)
            {
                BattleController.Instance.enemyField[target].def = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
    }

    public new void addActivate(int _value)
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].def += _value;
            if (BattleController.Instance.allyField[target].def < 0)
            {
                BattleController.Instance.allyField[target].def = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].def += _value;
            if (BattleController.Instance.enemyField[target].def < 0)
            {
                BattleController.Instance.enemyField[target].def = 0;
                BattleController.Instance.enemyField[target].deleteEffect(this);
            }
        }

        value += _value;
    }
}
