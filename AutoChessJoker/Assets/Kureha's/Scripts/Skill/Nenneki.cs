using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nenneki : Skill
{
    public Nenneki(int _skillLevel)
    {
        name = "粘液";
        description = "正面の敵に粘液を飛ばして敵の動きを鈍くする。(25/50/100) + 0.3魔力のダメージを与え、素早さを(5/10/20)下げる。";

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
            int enemy = BattleController.Instance.FrontSearch(false, field);

            BattleController.Instance.enemyField[enemy].DealAPDamage(Value);
            BattleController.Instance.enemyField[enemy].addEffect(new Betobeto(false, enemy, Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, false, enemy);
        }
        else
        {
            int ally = BattleController.Instance.FrontSearch(true, field);

            BattleController.Instance.allyField[ally].DealAPDamage(Value);
            BattleController.Instance.allyField[ally].addEffect(new Betobeto(true, ally, Value2));
            BattleController.Instance.WaitAnimation(SkillAnim, SkillSound, true, ally);
        }
    }
}