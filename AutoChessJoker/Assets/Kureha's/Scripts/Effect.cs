using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    public string name;
    public string description;

    public abstract void Activate();
}

public class Poison : Effect
{
    public int target;
    public int value;

    public Poison(int _target,int _value)
    {
        name = "��";
        description = "�ł�^����B���^�[���̏��߂ɒl�̃_���[�W��^����B";

        target = _target;
        value = _value;
    }

    public override void Activate()
    {

    }

    public void Excute()
    {

    }
}

public class Betobeto : Effect
{
    public int target;
    public int value;

    public Betobeto(int _target, int _value)
    {
        name = "�ׂƂׂ�";
        description = "�ׂƂׂƂ̏�ԁB�f�������ቺ����";
    }

    public override void Activate()
    {
        BattleController.Instance.enemyField[target].spd -= value;
    }
}