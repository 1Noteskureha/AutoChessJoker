using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public string name;
    public string description;

    public int skillLevel;

    protected GameObject SkillAnim;
    protected AudioClip SkillSound;

    public abstract void Activate(bool Ally,int field);

}
