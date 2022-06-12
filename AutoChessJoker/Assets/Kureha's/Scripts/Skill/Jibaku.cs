using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jibaku : Skill
{
    public Jibaku(int _skillLevel)
    {
        name = "自爆";
        description = "その場で爆発し、前列の敵全員に(100/200/300) + 2.0APのダメージを与え、自分のHPを0にする。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/fireBreath");
        SkillSound = Resources.Load<AudioClip>("Sound/fireBreath");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 100 + (int)(2.0f * mag);
        if (skillLevel == 2) Value = 200 + (int)(2.0f * mag);
        if (skillLevel == 3) Value = 300 + (int)(2.0f * mag);
        if (Ally)
        {
            for (int i = 0; i < 3; i++)
            {
                if (BattleController.Instance.enemyField[i].living)
                {
                    BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, i);
                    BattleController.Instance.enemyField[i].DealAPDamage(Value);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (BattleController.Instance.allyField[i].living)
                {
                    BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, i);
                    BattleController.Instance.allyField[i].DealAPDamage(Value);
                }
            }
        }
    }
}
