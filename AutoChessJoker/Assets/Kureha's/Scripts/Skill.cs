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
        name = "粘液";
        description = "粘液を飛ばして敵の動きを鈍くする。(25/50/100)のダメージを与え、素早さを(5/10/20)下げる。";

        skillLevel = _skillLevel;
    }

    //対象の位置
    public override void Activate(params int[] args)
    {
        if (skillLevel == 1) BattleController.Instance.enemyField[args[0]].DealAPDamage(25);
        if (skillLevel == 2) BattleController.Instance.enemyField[args[0]].DealAPDamage(50);
        if (skillLevel == 3) BattleController.Instance.enemyField[args[0]].DealAPDamage(100);
        if (skillLevel == 1) BattleController.Instance.enemyField[args[0]].ExecuteEffect(new Betobeto(args[0],5));   
        if(skillLevel == 2) BattleController.Instance.enemyField[args[0]].ExecuteEffect(new Betobeto(args[0],10));   
        if(skillLevel == 3) BattleController.Instance.enemyField[args[0]].ExecuteEffect(new Betobeto(args[0],20));   
    }
}