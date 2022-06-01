using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    public string name;
    public string description;
    public int rank;
    public int no;
    public bool living;

    public List<Symbol> symbol;

    public Sprite sprite;

    public int maxHp;
    public int hp;
    public int maxMana;
    public int mana = 0;
    public int baseAtk;
    public int atk;
    public int baseDef;
    public int def;
    public int baseMag;
    public int mag;
    public int baseRes;
    public int res;
    public int baseSpd;
    public int spd;
    public Skill skill;

    public List<Effect> effect;

    protected void Init()
    {
        hp = maxHp;
        mana = 0;
        atk = baseAtk;
        def = baseDef;
        mag = baseMag;
        res = baseRes;
        spd = baseSpd;
        living = true;
    }

    public void ExecuteEffect(Effect _effect)
    {   
        effect.Add(_effect);
        _effect.Activate();
    }

    public void DealADDamage(int DMG)
    {
        hp -= DMG - def;
        if (hp < 0)
        {
            hp = 0;
            living = false;
        }
    }

    public void DealAPDamage(int DMG)
    {
        hp -= DMG - res;
        if (hp < 0)
        {
            hp = 0;
            living = false;
        }
    }
}

//スライム
public class Slime : Monster
{
    public Slime(int _rank)
    {
        name = "スライム";
        description = "どろどろの粘液状の生物。";
        rank = _rank;
        no = 1000;

        symbol.Add(new Glass());
        //symbol.Add();
        //sprite = Resources.Load<Sprite>("Monster/Slime");

        maxHp = 26;
        maxMana = 100;
        baseDef = 0;
        baseMag = 25;
        baseRes = 1;
        baseSpd = 29;
        skill = new Nenneki(rank);

        Init();
    }
}