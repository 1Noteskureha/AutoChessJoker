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

    //追加で付与
    public void addActivate(int _value)
    {
        value += _value;
    }
}

