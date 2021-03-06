using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : Symbol
{
    public Sky()
    {
        name = "空";
        description = "素早さが(20/50/100)増える";
        activation = new List<int>() { 3, 4, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/sky");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("空のシンボル(" + level + ")が発動中");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {
            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.allyField[i].addEffect(new SpdChange(true, BattleController.Instance.allyField[i].field, 20));
                        break;
                    case 2:
                        BattleController.Instance.allyField[i].addEffect(new SpdChange(true, BattleController.Instance.allyField[i].field, 50));
                        break;
                    case 3:
                        BattleController.Instance.allyField[i].addEffect(new SpdChange(true, BattleController.Instance.allyField[i].field, 100));
                        break;
                }
            }
        }
    }
}
