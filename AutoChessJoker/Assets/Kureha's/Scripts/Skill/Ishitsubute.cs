using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ishitsubute : Skill
{
    public Ishitsubute(int _skillLevel)
    {
        name = "石つぶて";
        description = "石ころを投げつける。後衛を優先して(30/60/120) + 0.5魔力のダメージを与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Ishitsubute");
        SkillSound = Resources.Load<AudioClip>("Sound/Ishitsubute");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 30 + (int)(0.5 * mag);
        if (skillLevel == 2) Value = 60 + (int)(0.5 * mag);
        if (skillLevel == 3) Value = 120 + (int)(0.5 * mag);
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.BackSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, field);
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.BackSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}