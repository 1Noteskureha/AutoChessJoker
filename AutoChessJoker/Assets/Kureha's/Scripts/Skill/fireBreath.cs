using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : Skill
{
    public FireBreath(int _skillLevel)
    {
        name = "ファイアブレス";
        description = "前列の敵全員に(10/30/60) + 0.4APのダメージを与え、炎上を(5/10/20)与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/FireBreath");
        SkillSound = Resources.Load<AudioClip>("Sound/FireBreath");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 10 + (int)(0.4f * mag);
        int Value2 = 5;
        if (skillLevel == 2) Value = 30 + (int)(0.4f * mag);
        if (skillLevel == 2) Value2 = 10;
        if (skillLevel == 3) Value = 60 + (int)(0.4f * mag);
        if (skillLevel == 3) Value2 = 20;
        if (Ally)
        {
            for (int i = 0; i < 3; i++)
            {
                if (BattleController.Instance.enemyField[i].living)
                {
                    BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, i);
                    BattleController.Instance.enemyField[i].DealAPDamage(Value);
                    BattleController.Instance.enemyField[i].addTurnEnd(new OnFire(false, i, Value2));
                }
            }            
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (BattleController.Instance.allyField[i].living)
                {
                    BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, i);
                    BattleController.Instance.allyField[i].DealAPDamage(Value);
                    BattleController.Instance.allyField[i].addTurnEnd(new OnFire(true, i, Value2));
                }
            }
        }
    }
}
