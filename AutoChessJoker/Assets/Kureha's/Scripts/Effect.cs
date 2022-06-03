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

}

//Def�ω�
public class DefChange : Effect
{

}

//�U�����Ƃ̃}�i��
public class RegenMana : Effect
{
    public RegenMana(bool _ally, int _target, int _value)
    {
        name = "�}�i��";
        description = "�U�����Ƃ̃}�i�񕜗ʂ�(" +  value + ")������";

        ally = _ally;
        target = _target;
        value = _value;
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
        if(ally) BattleController.Instance.enemyField[target].spd -= value;
        else BattleController.Instance.enemyField[target].spd -= value;
    }

    public new void Excute()
    {

    }
}