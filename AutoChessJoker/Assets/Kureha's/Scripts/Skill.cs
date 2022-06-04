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
        name = "粘液";
        description = "正面の敵に粘液を飛ばして敵の動きを鈍くする。(25/50/100)のダメージを与え、素早さを(5/10/20)下げる。";

        skillLevel = _skillLevel;
    }

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
        name = "石つぶて";
        description = "石ころを投げつける。後衛を優先して(30/60/120)のダメージを与える。";

        skillLevel = _skillLevel;
    }

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