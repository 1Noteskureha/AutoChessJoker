using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParalyse : Effect
{
    public OnParalyse(bool _ally, int _target, int _value)
    {
        name = "麻痺";
        description = "麻痺している。100まで溜まると、次の行動ができなくなる。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Excute()
    {
        if (ally)
        {
            if (value >= 100)
            {
                BattleController.Instance.allyField[target].stan = true;
                value -= 100;
            }
        }
        else
        {
            if (value >= 100)
            {
                BattleController.Instance.allyField[target].stan = false;
                value -= 100;
            }
        }

        if(value <=0) BattleController.Instance.allyField[target].deleteTurnFirst(this);
    }
}
