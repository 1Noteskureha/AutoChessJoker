using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huiuchi : Skill
{
    public Huiuchi(int _skillLevel)
    {
        name = "ふいうち";
        description = "素早く動き、(10/30/50) + 0.2AP + 0.3素早さのダメージを与え、次の行動を無効にする。";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Huiuchi");
        SkillSound = Resources.Load<AudioClip>("Sound/Huiuchi");

    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;
        float spd;
        if (Ally) spd = BattleController.Instance.allyField[field].spd;
        else spd = BattleController.Instance.enemyField[field].spd;

        int Value = 10 + (int)(0.2 * mag) + (int)(0.1 * spd);
        if (skillLevel == 2) Value = 30 + (int)(0.2 * mag) + (int)(0.1 * spd);
        if (skillLevel == 3) Value = 50 + (int)(0.2 * mag) + (int)(0.1 * spd);
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].addTurnFirst(new OnSlip(false, BattleController.Instance.FrontSearch(false, field), 1));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, field);
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].addTurnFirst(new OnSlip(true, BattleController.Instance.FrontSearch(true, field), 1));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
