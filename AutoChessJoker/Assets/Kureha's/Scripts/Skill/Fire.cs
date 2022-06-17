using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Skill
{
    public Fire(int _skillLevel)
    {
        name = "ファイア";
        description = "炎を放つ。前衛を優先して(40/80/150) + 0.8魔力のダメージを与え、炎上を(5/10/20)与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Fire");
        SkillSound = Resources.Load<AudioClip>("Sound/Fire");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 40 + (int)(0.8 * mag);
        if (skillLevel == 2) Value = 80 + (int)(0.8 * mag);
        if (skillLevel == 3) Value = 150 + (int)(0.8 * mag);
        int Value2 = 5;
        if (skillLevel == 2) Value2 = 10;
        if (skillLevel == 3) Value2 = 20;
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].addTurnEnd(new OnFire(false, BattleController.Instance.FrontSearch(false, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.FrontSearch(false, field));
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].addTurnEnd(new OnFire(true, BattleController.Instance.FrontSearch(true, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
