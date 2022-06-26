using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPoison : Effect
{
    public OnPoison(bool _ally, int _target, int _value)
    {
        name = "毒";
        description = "毒を与える。毎ターンの初めに値のダメージを与える。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].DealTrueDamage(value);

            value--;
            if (value <= 0) BattleController.Instance.allyField[target].deleteTurnEnd(this);
        }
        else
        {
            BattleController.Instance.enemyField[target].DealTrueDamage(value);

            value--;
            if (value <= 0) BattleController.Instance.enemyField[target].deleteTurnEnd(this);
        }
    }
}
