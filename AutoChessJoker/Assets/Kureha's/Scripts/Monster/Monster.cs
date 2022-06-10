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

    public bool canSummon = true;//召喚可能か(基本モンスターじゃないか)
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
    public List<int> essense;//召喚可能時のエッセンス(9個)

    //ハンドル
    public List<Effect> effect = new List<Effect>();                 //恒久的状態異常
    public List<Effect> turnFirst = new List<Effect>();              //ターン初め
    public List<Effect> turnEnd = new List<Effect>();                //ターン終了時
    public List<Effect> thenDead = new List<Effect>();               //死亡時
    public List<Effect> thenAutoAttack = new List<Effect>();         //AAした時
    public List<Effect> thenDealAutoAttack = new List<Effect>();     //AA受けた時
    public List<Effect> thenSkill = new List<Effect>();              //スキルした時
    public List<Effect> thenDealSkill = new List<Effect>();          //スキル受けた時

    protected GameObject AAAnim;
    protected AudioClip AASound;

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

        AAAnim = Resources.Load<GameObject>("Animation/AA");
        AASound = Resources.Load<AudioClip>("Sound/AA");
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
                if (ally) BattleController.Instance.AddLog("味方の" + name + "(" + field + ")" + "の攻撃");
                else BattleController.Instance.AddLog("敵の" + name + "(" + field + ")" + "の攻撃");
                AutoAttack();
            }
            else
            {
                if (ally) BattleController.Instance.AddLog("味方の" + name + "(" + field + ")" + "の" + skill.name);
                else BattleController.Instance.AddLog("敵の" + name + "(" + field + ")" + "の" + skill.name);
                Skill();
            }
        }

        foreach (var end in turnEnd)
        {
            end.Excute();
        }

        BattleController.Instance.StateUpdate();
    }

    //通常攻撃
    public void AutoAttack()
    {   
        if (ally) {
            if (BattleController.Instance.enemyField[field%3].living)
            {
                BattleController.Instance.enemyField[field%3].DealADDamage(atk);
            }
            else if (field % 3 == 2 && BattleController.Instance.enemyField[field % 3 + 1].living)
            {
                BattleController.Instance.enemyField[field % 3 + 1].DealADDamage(atk);
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.enemyField[i%3].living)
                    {
                        BattleController.Instance.enemyField[i%3].DealADDamage(atk);
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
            else if (field % 3 == 2 && BattleController.Instance.allyField[field % 3 + 1].living)
            {
                BattleController.Instance.allyField[field % 3 + 1].DealADDamage(atk);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.allyField[i%3].living)
                    {
                        BattleController.Instance.allyField[i%3].DealADDamage(atk);
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

        if (ally) BattleController.Instance.AddLog($"味方の{name}は{DMG - def}のダメージを受けた");
        else BattleController.Instance.AddLog($"敵の{name}は{DMG - def}のダメージを受けた");

        foreach (var AA in thenDealAutoAttack)
        {
            AA.Excute();
        }

        BattleController.Instance.WaitAnimation(AAAnim,AASound,ally,field);

        Dead();
    }

    public void DealAPDamage(int DMG)
    {
        if (!living) return;
        hp -= Mathf.Clamp(DMG - res, 0, 1000000);

        if (ally) BattleController.Instance.AddLog($"味方の{name}は{DMG - res}のダメージを受けた");
        else BattleController.Instance.AddLog($"敵の{name}は{DMG - res}のダメージを受けた");

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

        if (ally) BattleController.Instance.AddLog($"味方の{name}は{DMG}のダメージを受けた");
        else BattleController.Instance.AddLog($"敵の{name}は{DMG}のダメージを受けた");

        Dead();

    }

    //リフレッシュ
    public void Refresh()
    {   
        if(living)
        done = false;
    }

    public void Dead()
    {
        BattleController.Instance.StateUpdate();

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

    protected IEnumerator AAAnimationWait()
    {
        

        yield break;
    }
}

//虚無
public class Blank : Monster
{
    public Blank()
    {
        no = 0;
        rank = 1;
        name = "スゴイ金玉";

        Init();
    }

    protected new void Init()
    {
        name = "";
        living = false;
        done = true;
        stan = false;

        sprite = Resources.Load<Sprite>("Monster/blank");
    }

    public new void Move() { }

    public new void Refresh() { }
    
}
