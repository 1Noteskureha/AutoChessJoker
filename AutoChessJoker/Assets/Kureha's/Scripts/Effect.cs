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

    //付与時の行動
    public void Activate() { }

    //継続的な行動
    public void Excute() { }
}

public class Poison : Effect
{
    public bool ally;
    public int target;
    public int value;

    public Poison(bool _ally,int _target,int _value)
    {
        name = "毒";
        description = "毒を与える。毎ターンの初めに値のダメージを与える。";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {

    }

    public new void Excute()
    {

    }
}

//Atk変化
public class AtkChange : Effect
{
    public AtkChange(bool _ally, int _target, int _value)
    {
        name = "攻撃力上昇";
        description = "攻撃力が(" + _value + ")増える";

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

//Def変化
public class DefChange : Effect
{
    public DefChange(bool _ally, int _target, int _value)
    {
        name = "防御力上昇";
        description = "防御力が(" + _value + ")増える";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].atk -= value;
            if (BattleController.Instance.allyField[target].atk < 0) BattleController.Instance.allyField[target].atk = 0;
        }
        else
        {
            BattleController.Instance.enemyField[target].atk -= value;
            if (BattleController.Instance.enemyField[target].atk < 0) BattleController.Instance.enemyField[target].atk = 0;
        }

    }
}

//攻撃ごとのマナ回復
public class RegenMana : Effect
{
    public RegenMana(bool _ally, int _target, int _value)
    {
        name = "マナ回復";
        description = "攻撃ごとのマナ回復量が(" +  _value + ")増える";

        ally = _ally;
        target = _target;
        value = _value;
    }

    //未完
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

public class Betobeto : Effect
{

    public Betobeto(bool _ally,int _target, int _value)
    {
        name = "べとべと";
        description = "べとべとの状態。素早さが低下する";

        ally = _ally;
        target = _target;
        value = _value;
    }

    public new void Activate()
    {
        if (ally)
        {
            BattleController.Instance.allyField[target].spd -= value;
            if (BattleController.Instance.allyField[target].spd < 0) BattleController.Instance.allyField[target].spd = 0;
        }
        else
        {
            BattleController.Instance.enemyField[target].spd -= value;
            if (BattleController.Instance.enemyField[target].spd < 0) BattleController.Instance.enemyField[target].spd = 0;
        }

    }
}