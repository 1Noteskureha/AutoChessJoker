using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betobeto : Effect
{

    public Betobeto(bool _ally, int _target, int _value)
    {
        name = "‚×‚Æ‚×‚Æ";
        description = "‚×‚Æ‚×‚Æ‚Ìó‘ÔB‘f‘‚³‚ª’á‰º‚·‚é";

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
