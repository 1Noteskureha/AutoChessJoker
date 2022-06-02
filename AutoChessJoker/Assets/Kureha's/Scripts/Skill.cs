using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public string name;
    public string description;

    public int skillLevel;

    public abstract void Activate(params int[] args);
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
    public override void Activate(params int[] args)
    {
        if (args[0] == 0)
        {
            if (skillLevel == 1) BattleController.Instance.enemyField[args[0]].DealAPDamage(25);
            if (skillLevel == 2) BattleController.Instance.enemyField[args[0]].DealAPDamage(50);
            if (skillLevel == 3) BattleController.Instance.enemyField[args[0]].DealAPDamage(100);
            if (skillLevel == 1) BattleController.Instance.enemyField[args[0]].ExecuteEffect(new Betobeto(false, args[1], 5));
            if (skillLevel == 2) BattleController.Instance.enemyField[args[0]].ExecuteEffect(new Betobeto(false, args[1], 10));
            if (skillLevel == 3) BattleController.Instance.enemyField[args[0]].ExecuteEffect(new Betobeto(false, args[1], 20));
        }
        else
        {
            if (skillLevel == 1) BattleController.Instance.allyField[args[0]].DealAPDamage(25);
            if (skillLevel == 2) BattleController.Instance.allyField[args[0]].DealAPDamage(50);
            if (skillLevel == 3) BattleController.Instance.allyField[args[0]].DealAPDamage(100);
            if (skillLevel == 1) BattleController.Instance.allyField[args[0]].ExecuteEffect(new Betobeto(true, args[1], 5));
            if (skillLevel == 2) BattleController.Instance.allyField[args[0]].ExecuteEffect(new Betobeto(true, args[1], 10));
            if (skillLevel == 3) BattleController.Instance.allyField[args[0]].ExecuteEffect(new Betobeto(true, args[1], 20));

        }
    }
}