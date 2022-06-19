using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holy : Symbol
{
    public Holy()
    {
        name = "聖";
        description = "死亡時、一度だけHPマックスで復活する";
        activation = new List<int>() { 8 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/holy");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("聖のシンボル(" + level + ")が発動中");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {
            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                BattleController.Instance.allyField[i].addThenDead(new Resurrection(true, BattleController.Instance.allyField[i].field, 1));
            }
        }
    }
}
