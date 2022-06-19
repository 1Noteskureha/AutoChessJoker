using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Symbol
{
    public Death()
    {
        name = "–»";
        description = "UŒ‚‚É‘Šè‚ğ‘¦€‚³‚¹‚é‰Â”\«‚ª(1/2/3)%ã¸";
        activation = new List<int>() { 3,5,8 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/death");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("–»‚ÌƒVƒ“ƒ{ƒ‹(" + level + ")‚ª”­“®’†");

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
