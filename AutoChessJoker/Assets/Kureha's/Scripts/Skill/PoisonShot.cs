using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonShot : Skill
{
    public PoisonShot(int _skillLevel)
    {
        name = "ポイズンショット";
        description = "毒の矢を放つ。前衛を優先して(10/20/40) + 0.2魔力のダメージを与え、毒を(5/10/20) + 0.2魔力与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/PoisonShot");
        SkillSound = Resources.Load<AudioClip>("Sound/PoisonShot");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 10 + (int)(0.2 * mag);
        if (skillLevel == 2) Value = 20 + (int)(0.2 * mag);
        if (skillLevel == 3) Value = 40 + (int)(0.2 * mag);
        int Value2 = 5 + (int)(0.2 * mag);
        if (skillLevel == 2) Value2 = 10 + (int)(0.2 * mag);
        if (skillLevel == 3) Value2 = 20 + (int)(0.2 * mag);
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].addTurnEnd(new OnPoison(false, BattleController.Instance.FrontSearch(false, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.FrontSearch(false, field));
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].addTurnEnd(new OnPoison(true, BattleController.Instance.FrontSearch(true, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
