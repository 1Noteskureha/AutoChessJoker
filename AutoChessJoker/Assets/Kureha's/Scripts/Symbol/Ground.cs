using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Symbol
{
    public Ground()
    {
        name = "地";
        description = "防御力が(10/20/50)増える";
        activation = new List<int>() { 3, 4, 7 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/ground");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("地のシンボル(" + level + ")が発動中");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {

            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.allyField[i].addEffect(new DefChange(true, BattleController.Instance.allyField[i].field, 10));
                        break;
                    case 2:
                        BattleController.Instance.allyField[i].addEffect(new DefChange(true, BattleController.Instance.allyField[i].field, 20));
                        break;
                    case 3:
                        BattleController.Instance.allyField[i].addEffect(new DefChange(true, BattleController.Instance.allyField[i].field, 50));
                        break;
                }
            }
        }
    }
}
