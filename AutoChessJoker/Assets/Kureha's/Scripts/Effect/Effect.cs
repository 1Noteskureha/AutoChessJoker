using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    public string name;
    public string description;

    public bool ally;
    public int target;
    public int value;

    //•t—^‚Ìs“®
    public void Activate() { }

    //Œp‘±“I‚Ès“®
    public void Excute() { }
}

//Atk•Ï‰»
public class AtkChange : Effect
{
    public AtkChange(bool _ally, int _target, int _value)
    {
        name = "UŒ‚—Íã¸";
        description = "UŒ‚—Í‚ª(" + _value + ")‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].def -= value;
            if (BattleController.Instance.allyField[target].def < 0) BattleController.Instance.allyField[target].def = 0;
        }
        else
        {
            BattleController.Instance.enemyField[target].def -= value;
            if (BattleController.Instance.enemyField[target].def < 0) BattleController.Instance.enemyField[target].def = 0;
        }

    }
}

//Def•Ï‰»
public class DefChange : Effect
{
    public DefChange(bool _ally, int _target, int _value)
    {
        name = "–hŒä—Íã¸";
        description = "–hŒä—Í‚ª(" + _value + ")‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].def += value;
        }
        else
        {
            BattleController.Instance.enemyField[target].def += value;
        }

    }
}

//UŒ‚‚²‚Æ‚Ìƒ}ƒi‰ñ•œ
public class RegenMana : Effect
{
    public RegenMana(bool _ally, int _target, int _value)
    {
        name = "ƒ}ƒi‰ñ•œ";
        description = "UŒ‚‚²‚Æ‚Ìƒ}ƒi‰ñ•œ—Ê‚ª(" +  _value + ")‘‚¦‚é";

        ally = _ally;
        target = _target;
        value = _value;
    }

    //–¢Š®
    public new void Excute()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].mana += value;
            if (BattleController.Instance.allyField[target].mana > BattleController.Instance.allyField[target].maxMana) BattleController.Instance.allyField[target].mana = BattleController.Instance.allyField[target].maxMana;
        }
        else
        {
            BattleController.Instance.enemyField[target].mana += value;
            if (BattleController.Instance.enemyField[target].mana > BattleController.Instance.enemyField[target].maxMana) BattleController.Instance.allyField[target].mana = BattleController.Instance.enemyField[target].maxMana;
        }

    }
}
