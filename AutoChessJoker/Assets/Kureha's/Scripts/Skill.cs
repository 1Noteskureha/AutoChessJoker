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
        name = "�S�t";
        description = "�S�t���΂��ēG�̓�����݂�����B(25/50/100)�̃_���[�W��^���A�f������(5/10/20)������B";
    }

    public override void Activate()
    {

    }
}