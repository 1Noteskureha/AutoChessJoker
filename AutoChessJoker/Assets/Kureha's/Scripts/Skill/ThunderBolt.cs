using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBolt : Skill
{
    public ThunderBolt(int _skillLevel)
    {
        name = "サンダーボルト";
        description = "雷を放つ。前衛を優先して(20/60/120) + 1.2魔力のダメージを与え、麻痺を(5/10/20)与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/ThunderBolt");
        SkillSound = Resources.Load<AudioClip>("Sound/ThunderBolt");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 20 + (int)(1.2 * mag);
        if (skillLevel == 2) Value = 60 + (int)(1.2 * mag);
        if (skillLevel == 3) Value = 120 + (int)(1.2 * mag);
        int Value2 = 5;
        if (skillLevel == 2) Value2 = 10;
        if (skillLevel == 3) Value2 = 20;
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].addTurnFirst(new OnParalyse(false, BattleController.Instance.FrontSearch(false, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.FrontSearch(false, field));
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].addTurnFirst(new OnParalyse(true, BattleController.Instance.FrontSearch(true, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
