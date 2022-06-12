using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill
{
    public Heal(int _skillLevel)
    {
        name = "ƒq[ƒ‹";
        description = "HP‚ªˆê”Ô’á‚¢–¡•û‚Ì‘Ì—Í‚ğ(20/50/100) + 1.0–‚—Í‰ñ•œ‚·‚éB";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Heal");
        SkillSound = Resources.Load<AudioClip>("Sound/Heal");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 20 + (int)(mag);
        if (skillLevel == 2) Value = 50 + (int)(mag);
        if (skillLevel == 3) Value = 100 + (int)(mag);
        if (Ally)
        {   
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.LessHPSearch(true, field));
            BattleController.Instance.allyField[BattleController.Instance.LessHPSearch(true, field)].DealHeal(Value);            
        }
        else
        {   
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.LessHPSearch(false, field));
            BattleController.Instance.enemyField[BattleController.Instance.LessHPSearch(false, field)].DealHeal(Value);
            
        }
    }
}
