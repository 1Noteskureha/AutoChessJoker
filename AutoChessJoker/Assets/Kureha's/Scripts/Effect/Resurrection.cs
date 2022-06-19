using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrection : Effect
{
    public Resurrection(bool _ally, int _target, int _value)
    {
        name = "復活";
        description = "死亡時、HPマックスで復活する";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].hp = BattleController.Instance.allyField[target].maxHp;
            BattleController.Instance.allyField[target].living = true;
            BattleController.Instance.allyField[target].deleteThenDead(this);
        }
        else
        {
            BattleController.Instance.enemyField[target].hp = BattleController.Instance.enemyField[target].maxHp;
            BattleController.Instance.enemyField[target].living = true;
            BattleController.Instance.enemyField[target].deleteThenDead(this);
        }

    }
}
