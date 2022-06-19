using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aqua : Symbol
{
    public Aqua()
    {
        name = "…";
        description = "–‚–@–hŒä—Í‚ª(10/20/50)‘‚¦‚é";
        activation = new List<int>() { 2, 4, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/aqua");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("…‚ÌƒVƒ“ƒ{ƒ‹(" + level + ")‚ª”­“®’†");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {
            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.allyField[i].addEffect(new ResChange(true, BattleController.Instance.allyField[i].field, 10));
                        break;
                    case 2:
                        BattleController.Instance.allyField[i].addEffect(new ResChange(true, BattleController.Instance.allyField[i].field, 20));
                        break;
                    case 3:
                        BattleController.Instance.allyField[i].addEffect(new ResChange(true, BattleController.Instance.allyField[i].field, 50));
                        break;
                }
            }
        }
    }
}
