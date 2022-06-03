using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public string name;
    public string description;

    public int skillLevel;

    public abstract void Activate(bool Ally,int field);

}

public class Nenneki : Skill
{   
    public Nenneki(int _skillLevel)
    {
        name = "”S‰t";
        description = "”S‰t‚ğ”ò‚Î‚µ‚Ä“G‚Ì“®‚«‚ğ“İ‚­‚·‚éB(25/50/100)‚Ìƒ_ƒ[ƒW‚ğ—^‚¦A‘f‘‚³‚ğ(5/10/20)‰º‚°‚éB";

        skillLevel = _skillLevel;
    }

    //‘ÎÛ‚ÌˆÊ’u
    public override void Activate(bool Ally, int field)
    {
        int Value = 25;
        int Value2 = 5;
        if (skillLevel == 2) Value = 50;
        if (skillLevel == 2) Value2 = 10;
        if (skillLevel == 3) Value = 100;
        if (skillLevel == 3) Value2 = 20;
        if (Ally)
        {
            BattleController.Instance.enemyField[field % 3].DealAPDamage(Value);
            BattleController.Instance.enemyField[field % 3].ExecuteEffect(new Betobeto(false, field % 3, Value2));
        }
        else
        {
            BattleController.Instance.allyField[field % 3].DealAPDamage(Value);
            BattleController.Instance.allyField[field % 3].ExecuteEffect(new Betobeto(true, field % 3, Value2));
        }
    }
}

public class Ishitsubute : Skill
{
    public Ishitsubute(int _skillLevel)
    {
        name = "Î‚Â‚Ô‚Ä";
        description = "Î‚±‚ë‚ğ“Š‚°‚Â‚¯‚éBŒã‰q‚ğ—Dæ‚µ‚Ä(30/60/120)‚Ìƒ_ƒ[ƒW‚ğ—^‚¦‚éB";

        skillLevel = _skillLevel;
    }

    //‘ÎÛ‚ÌˆÊ’u
    public override void Activate(bool Ally, int field)
    {

        int Value = 30;
        if (skillLevel == 2) Value = 60;
        if (skillLevel == 3) Value = 120;
        if (Ally)
        {  
            if (BattleController.Instance.enemyField[field % 3 + 3].living)
            {
                BattleController.Instance.enemyField[field % 3 + 3].DealAPDamage(Value);
            }
            else if(field%3 == 2 && BattleController.Instance.enemyField[field % 3 + 1].living)
            {
                BattleController.Instance.enemyField[field % 3 + 1].DealAPDamage(Value);
            }
            else
            {
                for(int i = 3;i < 6; i++)
                {
                    if (BattleController.Instance.enemyField[i].living)
                    {
                        BattleController.Instance.enemyField[i].DealAPDamage(Value);
                        break;
                    }
                }

                for (int i = 0; i < 3; i++)
                {   
                    if (BattleController.Instance.enemyField[i].living)
                    {
                        BattleController.Instance.enemyField[i].DealAPDamage(Value);
                        break;
                    }
                }
            }
        }
        else
        {
            if (BattleController.Instance.allyField[field % 3 + 3].living)
            {
                BattleController.Instance.allyField[field % 3 + 3].DealAPDamage(Value);
            }
            else if (field % 3 == 2 && BattleController.Instance.allyField[field % 3 + 1].living)
            {
                BattleController.Instance.allyField[field % 3 + 1].DealAPDamage(Value);
            }
            else
            {
                for (int i = 3; i < 6; i++)
                {
                    if (BattleController.Instance.allyField[i].living)
                    {
                        BattleController.Instance.allyField[i].DealAPDamage(Value);
                        break;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.allyField[i].living)
                    {
                        BattleController.Instance.allyField[i].DealAPDamage(Value);
                        break;
                    }
                }
            }
        }
    }
}