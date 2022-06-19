using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsume : Skill
{
    public Tsume(int _skillLevel)
    {
        name = "爪";
        description = "正面の敵を爪で2回切り裂き、(20/40/60) + 0.3魔力のダメージを2回与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Tsume");
        SkillSound = Resources.Load<AudioClip>("Sound/Tsume");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 20 + (int)(0.3 * mag);
        if (skillLevel == 2) Value = 40 + (int)(0.3 * mag);
        if (skillLevel == 3) Value = 60 + (int)(0.3 * mag);
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, field);
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
