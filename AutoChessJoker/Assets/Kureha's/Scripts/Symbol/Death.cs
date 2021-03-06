using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Symbol
{
    public Death()
    {
        name = "冥";
        description = "攻撃時に相手を即死させる可能性が(1/2/3)%上昇";
        activation = new List<int>() { 3,5,8 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/death");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("冥のシンボル(" + level + ")が発動中");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {   

            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.allyField[i].addThenDealAutoAttack(new Chimei(true, BattleController.Instance.allyField[i].field, 1));
                        break;
                    case 2:
                        BattleController.Instance.allyField[i].addThenDealAutoAttack(new Chimei(true, BattleController.Instance.allyField[i].field, 2));
                        break;
                    case 3:
                        BattleController.Instance.allyField[i].addThenDealAutoAttack(new Chimei(true, BattleController.Instance.allyField[i].field, 3));
                        break;
                }                
            }
        }
    }
}
