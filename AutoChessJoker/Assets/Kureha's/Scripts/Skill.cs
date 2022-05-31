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
        name = "”S‰t";
        description = "”S‰t‚ğ”ò‚Î‚µ‚Ä“G‚Ì“®‚«‚ğ“İ‚­‚·‚éB(25/50/100)‚Ìƒ_ƒ[ƒW‚ğ—^‚¦A‘f‘‚³‚ğ(5/10/20)‰º‚°‚éB";
    }

    public override void Activate()
    {

    }
}