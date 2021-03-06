using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast : Symbol
{
    public Beast()
    {
        name = "獣";
        description = "最大体力が(100/200/500)増える";
        activation = new List<int>() { 2, 4, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/beast");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("獣のシンボル(" + level + ")が発動中");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {
            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.allyField[i].addEffect(new HPChange(true, BattleController.Instance.allyField[i].field, 100));
                        break;
                    case 2:
                        BattleController.Instance.allyField[i].addEffect(new HPChange(true, BattleController.Instance.allyField[i].field, 200));
                        break;
                    case 3:
                        BattleController.Instance.allyField[i].addEffect(new HPChange(true, BattleController.Instance.allyField[i].field, 500));
                        break;
                }
            }
        }
    }
}
