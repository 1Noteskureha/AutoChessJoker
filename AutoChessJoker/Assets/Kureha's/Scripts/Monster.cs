using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    public string name;
    public string description;
    public int rank;
    public int no;
    
    public bool living;         //生死
    public bool ally;           //味方か敵か
    public int field;           //フィールドのどの場所か
    public bool done;           //行動済みか
    public bool stan;           //スタンしているか

    //所持シンボル
    public List<Symbol> symbol = new List<Symbol>();

    //立ち絵
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

    //ハンドル
    public List<Effect> effect = new List<Effect>();                 //恒久的状態異常
    public List<Effect> turnFirst = new List<Effect>();              //ターン初め
    public List<Effect> turnEnd = new List<Effect>();                //ターン終了時
    public List<Effect> thenDead = new List<Effect>();               //死亡時
    public List<Effect> thenAutoAttack = new List<Effect>();         //AAした時
    public List<Effect> thenDealAutoAttack = new List<Effect>();     //AA受けた時
    public List<Effect> thenSkill = new List<Effect>();              //スキルした時
    public List<Effect> thenDealSkill = new List<Effect>();          //スキル受けた時

    protected void Init()
    {
        if (rank == 2)
        {
            maxHp *= 2;
            baseAtk *= 2;
            baseDef *= 2;
            baseMag *= 2;
            baseRes *= 2;
            baseSpd *= 2;
        }
        else if(rank == 3)
        {
            maxHp *= 5;
            baseAtk *= 5;
            baseDef *= 5;
            baseMag *= 5;
            baseRes *= 5;
            baseSpd *= 5;
        }
        hp = maxHp;
        mana = 0;
        atk = baseAtk;
        def = baseDef;
        mag = baseMag;
        res = baseRes;
        spd = baseSpd;
        living = true;
        done = false;
        stan = false;
    }

    public void Move()
    {
        
        if (!living) return;

        foreach (var first in turnFirst)
        {
            first.Excute();
        }

        if (!stan)
        {
            if (mana < maxMana)
            {
                if (ally) Debug.Log("味方の" + name + "(" + field + ")" + "の攻撃");
                else Debug.Log("敵の" + name + "(" + field + ")" + "の攻撃");
                AutoAttack();
            }
            else
            {
                if (ally) Debug.Log("味方の" + name + "(" + field + ")" + "のスキル");
                else Debug.Log("敵の" + name + "(" + field + ")" + "のスキル");
                Skill();
            }
        }

        foreach (var end in turnEnd)
        {
            end.Excute();
        }
    }

    //通常攻撃
    public void AutoAttack()
    {   
        if (ally) {
            if (BattleController.Instance.enemyField[field%3].living)
            {
                BattleController.Instance.enemyField[field%3].DealADDamage(atk);
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.enemyField[i%3].living)
                    {
                        BattleController.Instance.enemyField[field%3].DealADDamage(atk);
                        break;
                    }
                }
            }
        }
        else
        {
            if (BattleController.Instance.allyField[field%3].living)
            {
                BattleController.Instance.allyField[field%3].DealADDamage(atk);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.allyField[i%3].living)
                    {
                        BattleController.Instance.allyField[field%3].DealADDamage(atk);
                        break;
                    }
                }
            }
        }

        foreach (var AA in thenAutoAttack) {
            AA.Excute();
        }

        //マナはmagだけ上昇
        mana += mag;
        if (mana > maxMana) mana = maxMana;
    }

    public void Skill()
    {
        mana = 0;
        skill.Activate(ally,field);
    }

    public void ExecuteEffect(Effect _effect)
    {
        if (!living) return;
        effect.Add(_effect);
        _effect.Activate();
    }

    public void DealADDamage(int DMG)
    {
        if (!living) return;
        
        hp -= Mathf.Clamp(DMG - def,0,1000000);

        foreach (var AA in thenDealAutoAttack)
        {
            AA.Excute();
        }

        Dead();
    }

    public void DealAPDamage(int DMG)
    {
        if (!living) return;
        hp -= Mathf.Clamp(DMG - res, 0, 1000000);

        Debug.Log(hp);
        foreach (var sk in thenDealSkill)
        {
            sk.Excute();
        }

        Dead();
    }

    public void DealTrueDamage(int DMG)
    {
        if (!living) return;
        hp -= Mathf.Clamp(DMG, 0, 1000000);
        Dead();

    }

    //リフレッシュ
    public void Refresh()
    {   
        if(!living)
        done = false;
    }

        public void Dead()
    {

        if (hp > 0) return;
        hp = 0;
        living = false;
        foreach (var d in thenDead)
        {
            d.Excute();
        }
        if (hp <= 0)
        {
            BattleController.Instance.MonsterDead(ally,field);
        }
    }
}

//虚無
public class Blank : Monster
{
    public Blank()
    {
        no = 0;

        Init();
    }

    protected new void Init()
    {        
        living = false;
        done = true;
        stan = false;

        sprite = Resources.Load<Sprite>("Monster/blank");
    }

    public new void Move() { }

    public new void Refresh() { }
    
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

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/slime");

        maxHp = 26;
        maxMana = 100;
        baseAtk = 10;
        baseDef = 0;
        baseMag = 25;
        baseRes = 1;
        baseSpd = 29;
        skill = new Nenneki(rank);

        Init();
    }
}

public class Goblin : Monster
{
    public Goblin(int _rank)
    {
        name = "ゴブリン";
        description = "小型の亜人族。いたずらが大好き。";
        rank = _rank;
        no = 2000;

        //Debug.Log(no);

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/goblin");

        maxHp = 28;
        maxMana = 50;
        baseAtk = 14;
        baseDef = 0;
        baseMag = 8;
        baseRes = 0;
        baseSpd = 34;
        skill = new Ishitsubute(rank);

        Init();
    }
}