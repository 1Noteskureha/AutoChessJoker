using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyogiri : Skill
{
    public Kyogiri(int _skillLevel)
    {
        name = "���a��";
        description = "���ʂ̓G�������͂Ő؂荏�ށB(35/80/130) + 0.5���͂̃_���[�W��^����B���g���O��ɂ��Ȃ��Ǝ��s����B";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Kyogiri");
        SkillSound = Resources.Load<AudioClip>("Sound/Kyogiri");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if (Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 35 + (int)(mag * 0.5f);
        if (skillLevel == 2) Value = 50 + (int)(mag * 0.5f);
        if (skillLevel == 3) Value = 100 + (int)(mag * 0.5f);

        if (field >= 4) return;

        BattleController.Instance.AddLog("���a��͑O��ɂ��Ȃ����ߎ��s����");

        if (Ally)
        {            
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.FrontSearch(true, field));
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}
