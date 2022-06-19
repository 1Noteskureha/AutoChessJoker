using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimei : Effect
{
    public Chimei(bool _ally, int _target, int _value)
    {
        name = "’v–½";
        description = "’ÊíUŒ‚‚É“G‚ğ‘¦€‚³‚¹‚éŠm—¦‚ª(" + _value + ")%‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        int random = Random.Range(0,100);

        if (ally)
        {
            if (random <= value)
            {
                int position = BattleController.Instance.FrontSearch(ally, target);                
                BattleController.Instance.enemyField[position].hp = 0;
                BattleController.Instance.enemyField[position].Dead();

            }
        }
        else
        {
            if (random <= value)
            {
                int position = BattleController.Instance.FrontSearch(ally, target);
                BattleController.Instance.allyField[position].hp = 0;
                BattleController.Instance.enemyField[position].Dead();
            }
        }

    }

}
