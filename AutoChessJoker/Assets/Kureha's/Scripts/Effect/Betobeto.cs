using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betobeto : Effect
{

    public Betobeto(bool _ally, int _target, int _value)
    {
        name = "�ׂƂׂ�";
        description = "�ׂƂׂƂ̏�ԁB�f�������ቺ����";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].spd -= value;
            if (BattleController.Instance.allyField[target].spd < 0) BattleController.Instance.allyField[target].spd = 0;
        }
        else
        {
            BattleController.Instance.enemyField[target].spd -= value;
            if (BattleController.Instance.enemyField[target].spd < 0) BattleController.Instance.enemyField[target].spd = 0;
        }

    }
}
