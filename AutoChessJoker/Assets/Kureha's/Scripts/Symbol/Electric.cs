using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : Symbol
{
    public Electric()
    {
        name = "雷";
        description = "相手が行動するたび、相手に麻痺を(10/20)与える。。\n" +
                      "麻痺は100溜まると行動不能になる。";
        activation = new List<int>() { 3, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/electric");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("雷のシンボル(" + level + ")が発動中");

        for (int i = 0; i < BattleController.Instance.enemyField.Count; i++)
        {
            if (BattleController.Instance.enemyField[i].no != 0 && BattleController.Instance.enemyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.enemyField[i].addTurnEnd(new Taiden(false, BattleController.Instance.enemyField[i].field, 10));
                        break;
                    case 2:
                        BattleController.Instance.enemyField[i].addTurnEnd(new Taiden(false, BattleController.Instance.enemyField[i].field, 20));
                        break;
                }
            }
        }
    }
}
