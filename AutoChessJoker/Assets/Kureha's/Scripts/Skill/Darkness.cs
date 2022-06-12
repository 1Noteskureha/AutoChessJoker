using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : Skill
{
    public Darkness(int _skillLevel)
    {
        name = "ダークネス";
        description = "混沌の闇で包み込み敵全体に(0/50/100) + 0.5魔力の確定ダメージを与えて同じだけマナを減少させる";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/FireBreath");
        SkillSound = Resources.Load<AudioClip>("Sound/FireBreath");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 0 + (int)(0.5f * mag);
        if (skillLevel == 2) Value = 50 + (int)(0.5f * mag);
        if (skillLevel == 3) Value = 100 + (int)(0.5f * mag);
        if (Ally)
        {
            for (int i = 0; i < 6; i++)
            {
                if (BattleController.Instance.enemyField[i].living)
                {
                    BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, i);
                    BattleController.Instance.enemyField[i].DealAPDamage(Value);
                    BattleController.Instance.enemyField[i].mana -= Value;
                    if (BattleController.Instance.enemyField[i].mana < 0) BattleController.Instance.enemyField[i].mana = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if (BattleController.Instance.allyField[i].living)
                {
                    BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, i);
                    BattleController.Instance.allyField[i].DealAPDamage(Value);
                    BattleController.Instance.allyField[i].mana -= Value;
                    if (BattleController.Instance.allyField[i].mana < 0) BattleController.Instance.allyField[i].mana = 0;
                }
            }
        }
    }
}
