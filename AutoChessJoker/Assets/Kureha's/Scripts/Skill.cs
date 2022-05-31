using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public string name;
    public string description;

    public abstract void Activate();
}

public class Nenneki : Skill
{   
    public Nenneki()
    {
        name = "粘液";
        description = "粘液を飛ばして敵の動きを鈍くする。(25/50/100)のダメージを与え、素早さを(5/10/20)下げる。";
    }

    public override void Activate()
    {

    }
}