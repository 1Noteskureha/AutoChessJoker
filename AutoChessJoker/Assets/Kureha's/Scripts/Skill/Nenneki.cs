using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nenneki : Skill
{
    public Nenneki(int _skillLevel)
    {
        name = "”S‰t";
        description = "³–Ê‚Ì“G‚É”S‰t‚ğ”ò‚Î‚µ‚Ä“G‚Ì“®‚«‚ğ“İ‚­‚·‚éB(25/50/100) + 0.3–‚—Í‚Ìƒ_ƒ[ƒW‚ğ—^‚¦A‘f‘‚³‚ğ(5/10/20)‰º‚°‚éB";

        skillLevel = _skillLevel;

        SkillAnim = Resources.Load<GameObject>("Animation/Nenneki");
        SkillSound = Resources.Load<AudioClip>("Sound/Nenneki");
    }

    public override void Activate(bool Ally, int field)
    {
        float mag;
        if(Ally) mag = BattleController.Instance.allyField[field].mag;
        else mag = BattleController.Instance.enemyField[field].mag;

        int Value = 25 + (int)(mag * 0.3f);
        int Value2 = 5;
        if (skillLevel == 2) Value = 50 + (int)(mag * 0.3f);
        if (skillLevel == 2) Value2 = 10;
        if (skillLevel == 3) Value = 100 + (int)(mag * 0.3f);
        if (skillLevel == 3) Value2 = 20;
        if (Ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealAPDamage(Value);
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].addEffect(new Betobeto(false, BattleController.Instance.FrontSearch(false, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, BattleController.Instance.FrontSearch(true, field));
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealAPDamage(Value);
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].addEffect(new Betobeto(true, BattleController.Instance.FrontSearch(true, field), Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, BattleController.Instance.FrontSearch(true, field));
        }
    }
}