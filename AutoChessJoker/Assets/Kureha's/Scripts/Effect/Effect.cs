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

    //�ǉ��ŕt�^
    public void addActivate(int _value)
    {
        value += _value;
    }
}

