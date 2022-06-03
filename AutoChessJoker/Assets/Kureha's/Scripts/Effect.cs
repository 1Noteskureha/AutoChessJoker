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

    //�t�^���̍s��
    public void Activate() { }

    //�p���I�ȍs��
    public void Excute() { }
}

public class Poison : Effect
{
    public bool ally;
    public int target;
    public int value;

    public Poison(bool _ally,int _target,int _value)
    {
        name = "��";
        description = "�ł�^����B���^�[���̏��߂ɒl�̃_���[�W��^����B";

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

//Atk�ω�
public class AtkChange : Effect
{
    public AtkChange(bool _ally, int _target, int _value)
    {
        name = "�U���͏㏸";
        description = "�U���͂�(" + _value + ")������";

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

//Def�ω�
public class DefChange : Effect
{
    public DefChange(bool _ally, int _target, int _value)
    {
        name = "�h��͏㏸";
        description = "�h��͂�(" + _value + ")������";

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

//�U�����Ƃ̃}�i��
public class RegenMana : Effect
{
    public RegenMana(bool _ally, int _target, int _value)
    {
        name = "�}�i��";
        description = "�U�����Ƃ̃}�i�񕜗ʂ�(" +  _value + ")������";

        ally = _ally;
        target = _target;
        value = _value;
    }

    //����
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
        name = "�ׂƂׂ�";
        description = "�ׂƂׂƂ̏�ԁB�f�������ቺ����";

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