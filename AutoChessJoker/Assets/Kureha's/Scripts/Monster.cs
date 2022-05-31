using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    public string name;
    public string description;
    public int rank;
    public int no;

    public Sprite sprite;

    public int maxHp;
    public int hp;    
    public int mana = 0;
    public int maxMana;
    public int atk;
    public int def;
    public int mag;
    public int res;
    public int spd;
    public Skill skill;
}

//スライム
public class Slime : Monster
{
    public Slime()
    {
        name = "スライム";
        description = "どろどろの粘液状の生物。";
        rank = 1;
        no = 1000;

        sprite = Resources.Load<Sprite>("Monster/Slime");

        hp = maxHp;
        maxHp = 26;
        maxMana = 100;
        atk = 12;
        def = 0;
        mag = 25;
        res = 1;
        spd = 29;
        skill = new Nenneki();
    }
}