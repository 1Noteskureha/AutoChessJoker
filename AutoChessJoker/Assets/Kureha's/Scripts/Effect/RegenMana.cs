using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻撃ごとのマナ回復
public class RegenMana : Effect
{
    public RegenMana(bool _ally, int _target, int _value)
    {
        name = "マナ回復";
        description = "攻撃ごとのマナ回復量が(" + _value + ")増える";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].mana += value;
            if (BattleController.Instance.allyField[target].mana > BattleController.Instance.allyField[target].maxMana) BattleController.Instance.allyField[target].mana = BattleController.Instance.allyField[target].maxMana;
        }
        else
        {
            BattleController.Instance.enemyField[target].mana += value;
            if (BattleController.Instance.enemyField[target].mana > BattleController.Instance.enemyField[target].maxMana) BattleController.Instance.allyField[target].mana = BattleController.Instance.enemyField[target].maxMana;
        }

    }
}