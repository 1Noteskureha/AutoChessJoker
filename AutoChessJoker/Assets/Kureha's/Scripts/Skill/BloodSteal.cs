using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ãzåå
public class BloodSteal : Skill
{
    public BloodSteal(int _skillLevel)
    {
        name = "ãzåå";
        description = "ê≥ñ ÇÃìGÇÃååÇãzÇ¢ÅA(20/40/80) + 0.4APÇÃÉ_ÉÅÅ[ÉWÇó^Ç¶ÇªÇÃîºï™ÇÃílâÒïúÇ∑ÇÈ";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/BloodSteal");
        SkillSound = Resources.Load<AudioClip>("Sound/BloodSteal");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 20 + (int)(0.4f * mag);
        if (skillLevel == 2) Value = 40 + (int)(0.4f * mag);
        if (skillLevel == 3) Value = 80 + (int)(0.4f * mag);
        if (Ally)
        {
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.LessHPSearch(false, field));
            int value2 = BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[field].DealHeal(value2);
        }
        else
        {
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.LessHPSearch(true, field));
            int value2 = BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[field].DealHeal(value2);
        }
    }
}
