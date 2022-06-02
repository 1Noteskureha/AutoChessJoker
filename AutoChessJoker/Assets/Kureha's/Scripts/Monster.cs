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
    
    public bool living;         //����
    public bool ally;           //�������G��
    public int field;           //�t�B�[���h�̂ǂ̏ꏊ��
    public bool done;           //�s���ς݂�
    public bool stan;           //�X�^�����Ă��邩

    //�����V���{��
    public List<Symbol> symbol;

    //�����G
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

    //�n���h��
    public List<Effect> effect;                 //�P�v�I��Ԉُ�
    public List<Effect> turnFirst;              //�^�[������
    public List<Effect> turnEnd;                //�^�[���I����
    public List<Effect> thenDead;               //���S��
    public List<Effect> thenAutoAttack;         //AA������
    public List<Effect> thenDealAutoAttack;     //AA�󂯂���
    public List<Effect> thenSkill;              //�X�L��������
    public List<Effect> thenDealSkill;          //�X�L���󂯂���

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
                AutoAttack();
            }
            else
            {
                Skill();
            }
        }

        foreach (var end in turnEnd)
        {
            end.Excute();
        }
    }

    public void AutoAttack()
    {   
        if (ally) {
            if (BattleController.Instance.enemyField[field] != null)
            {
                BattleController.Instance.enemyField[field].DealADDamage(atk);
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.enemyField[i] != null)
                    {
                        BattleController.Instance.enemyField[field].DealADDamage(atk);
                        break;
                    }
                }
            }
        }
        else
        {
            if (BattleController.Instance.allyField[field] != null)
            {
                BattleController.Instance.allyField[field].DealADDamage(atk);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (BattleController.Instance.allyField[i] != null)
                    {
                        BattleController.Instance.allyField[field].DealADDamage(atk);
                        break;
                    }
                }
            }
        }

        foreach (var AA in thenAutoAttack) {
            AA.Excute();
        }

        mana += 10;
        if (mana > maxMana) mana = maxMana;
    }

    public void Skill() { }


    public void ExecuteEffect(Effect _effect)
    {   
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
//����
public class Blank : Monster
{
    public Blank()
    {
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
}

//�X���C��
public class Slime : Monster
{
    public Slime(int _rank)
    {
        name = "�X���C��";
        description = "�ǂ�ǂ�̔S�t��̐����B";
        rank = _rank;
        no = 1000;

        symbol.Add(new Glass());
        //symbol.Add();
        sprite = Resources.Load<Sprite>("Monster/slime");

        maxHp = 26;
        maxMana = 100;
        baseDef = 0;
        baseMag = 25;
        baseRes = 1;
        baseSpd = 29;
        skill = new Nenneki(rank);

        Init();
    }

    public new void Skill()
    {
        mana = 0;
        skill.Activate();
    }
}