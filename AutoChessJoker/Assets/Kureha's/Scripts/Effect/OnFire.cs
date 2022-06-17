using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : Effect
{

    public OnFire(bool _ally, int _target, int _value)
    {
        name = "炎上";
        description = "炎上している。攻撃力が低下し、毎ターン終了時確定ダメージを受け値が減る。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].atk -= value;
            if (BattleController.Instance.allyField[target].atk < 0) BattleController.Instance.allyField[target].atk = 0;
        }
        else
        {
            BattleController.Instance.enemyField[target].atk -= value;
            if (BattleController.Instance.enemyField[target].atk < 0) BattleController.Instance.enemyField[target].atk = 0;
        }

    }

    public new void Excute()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].DealTrueDamage(value);
            //攻撃力を戻す
            if (value % 2 == 0)
            {
                value /= 2;
                BattleController.Instance.allyField[target].atk += value;
            }
            else
            {
                value /= 2;
                BattleController.Instance.allyField[target].atk += value + 1;
            }
        }
        else
        {
            BattleController.Instance.enemyField[target].DealTrueDamage(value);
            //攻撃力を戻す
            if (value % 2 == 0)
            {
                value /= 2;
                BattleController.Instance.enemyField[target].atk += value;
            }
            else
            {
                value /= 2;
                BattleController.Instance.enemyField[target].atk += value + 1;
            }
        }

        if(value <= 0) BattleController.Instance.allyField[target].deleteTurnFirst(this);
    }
}
