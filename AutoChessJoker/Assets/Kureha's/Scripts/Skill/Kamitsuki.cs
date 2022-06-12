using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamitsuki : Skill
{
    public Kamitsuki(int _skillLevel)
    {
        name = "かみつき";
        description = "正面の敵にかみつき、(60/80/100) + 0.2AP + 0.1自身の最大HPのダメージを与える。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Kamitsuki");
        SkillSound = Resources.Load<AudioClip>("Sound/Kamitsuki");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;
        float HP;
        if (Ally) HP = BattleController.Instance.allyField[field].maxHp;
        else HP = BattleController.Instance.enemyField[field].maxHp;

        int Value = 60 + (int)(0.2 * mag) + (int)(0.1 * HP);
        if (skillLevel == 2) Value = 80 + (int)(0.2 * mag) + (int)(0.1 * HP);
        if (skillLevel == 3) Value = 100 + (int)(0.2 * mag) + (int)(0.1 * HP);
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, field);
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
