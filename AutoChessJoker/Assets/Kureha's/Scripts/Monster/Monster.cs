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

    public bool canSummon = true;//�����\��(��{�����X�^�[����Ȃ���)
    public bool living;         //����
    public bool ally;           //�������G��
    public int field;           //�t�B�[���h�̂ǂ̏ꏊ��
    public bool done;           //�s���ς݂�
    public bool stan;           //�X�^�����Ă��邩    

    //�����V���{��
    public List<Symbol> symbol = new List<Symbol>();

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
    public List<int> essense;//�����\���̃G�b�Z���X(9��)

    //�n���h��
    public List<Effect> effect = new List<Effect>();                 //�P�v�I��Ԉُ�
    public List<Effect> turnFirst = new List<Effect>();              //�^�[������
    public List<Effect> turnEnd = new List<Effect>();                //�^�[���I����
    public List<Effect> thenDead = new List<Effect>();               //���S��
    public List<Effect> thenAutoAttack = new List<Effect>();         //AA������
    public List<Effect> thenDealAutoAttack = new List<Effect>();     //AA�󂯂���
    public List<Effect> thenSkill = new List<Effect>();              //�X�L��������
    public List<Effect> thenDealSkill = new List<Effect>();          //�X�L���󂯂���

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
                if (ally) BattleController.Instance.AddLog("������" + name + "(" + field + ")" + "�̍U��");
                else BattleController.Instance.AddLog("�G��" + name + "(" + field + ")" + "�̍U��");
                AutoAttack();
            }
            else
            {
                if (ally) BattleController.Instance.AddLog("������" + name + "(" + field + ")" + "��" + skill.name);
                else BattleController.Instance.AddLog("�G��" + name + "(" + field + ")" + "��" + skill.name);
                Skill();
            }
        }

        foreach (var end in turnEnd)
        {
            end.Excute();
        }

        BattleController.Instance.StateUpdate();
    }

    //�ʏ�U��
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

        //�}�i��mag�����㏸
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

        if (ally) BattleController.Instance.AddLog($"������{name}��{DMG - def}�̃_���[�W���󂯂�");
        else BattleController.Instance.AddLog($"�G��{name}��{DMG - def}�̃_���[�W���󂯂�");

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

        if (ally) BattleController.Instance.AddLog($"������{name}��{DMG - res}�̃_���[�W���󂯂�");
        else BattleController.Instance.AddLog($"�G��{name}��{DMG - res}�̃_���[�W���󂯂�");

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

        if (ally) BattleController.Instance.AddLog($"������{name}��{DMG}�̃_���[�W���󂯂�");
        else BattleController.Instance.AddLog($"�G��{name}��{DMG}�̃_���[�W���󂯂�");

        Dead();

    }

    //���t���b�V��
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

//����
public class Blank : Monster
{
    public Blank()
    {
        no = 0;
        rank = 1;
        name = "�X�S�C����";

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
