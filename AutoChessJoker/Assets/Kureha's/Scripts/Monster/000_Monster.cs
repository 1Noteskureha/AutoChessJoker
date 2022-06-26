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
            maxHp *= 3;
            baseAtk *= 3;
            baseDef *= 3;
            baseMag *= 3;
            baseRes *= 3;
            baseSpd *= 3;
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
        

        done = true;
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
        if (ally)
        {
            BattleController.Instance.enemyField[BattleController.Instance.FrontSearch(false, field)].DealADDamage(atk);
        }
        else
        {
            BattleController.Instance.allyField[BattleController.Instance.FrontSearch(true, field)].DealADDamage(atk);
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

    #region Effect
    public void addEffect(Effect _effect)
    {
        if (!living) return;
        for(int i = 0; i < effect.Count; i++)
        {
            if (effect[i].name == _effect.name)
            {
                //effect[i].value += _effect.value;
                effect[i].addActivate(_effect.value);
                return;
            }
        }

        effect.Add(_effect);
        _effect.Activate();
    }

    public void deleteEffect(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < effect.Count; i++)
        {
            if (effect[i].name == _effect.name)
            {
                effect.RemoveAt(i);
                return;
            }
        }

        return;
    }

    public void addTurnFirst(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < turnFirst.Count; i++)
        {
            if (turnFirst[i].name == _effect.name)
            {
                //turnFirst[i].value += _effect.value;
                turnFirst[i].addActivate(_effect.value);
                return;
            }
        }

        turnFirst.Add(_effect);
        _effect.Activate();
    }

    public void deleteTurnFirst(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < turnFirst.Count; i++)
        {
            if (turnFirst[i].name == _effect.name)
            {
                turnFirst.RemoveAt(i);
                return;
            }
        }

        return;
    }

    public void addTurnEnd(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < turnEnd.Count; i++)
        {
            if (turnEnd[i].name == _effect.name)
            {
                //turnEnd[i].value += _effect.value;
                turnEnd[i].addActivate(_effect.value);
                return;
            }
        }

        turnEnd.Add(_effect);
        _effect.Activate();
    }

    public void deleteTurnEnd(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < turnEnd.Count; i++)
        {
            if (turnEnd[i].name == _effect.name)
            {
                turnEnd.RemoveAt(i);
                return;
            }
        }

        return;
    }

    public void addThenDead(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < thenDead.Count; i++)
        {
            if (thenDead[i].name == _effect.name)
            {
                //turnFirst[i].value += _effect.value;
                thenDead[i].addActivate(_effect.value);
                return;
            }
        }

        thenDead.Add(_effect);
        _effect.Activate();
    }

    public void deleteThenDead(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < thenDead.Count; i++)
        {
            if (thenDead[i].name == _effect.name)
            {
                thenDead.RemoveAt(i);
                return;
            }
        }

        return;
    }

    public void addThenDealAutoAttack(Effect _effect)
    {
        if (!living) return;
        for (int i = 0; i < thenDealAutoAttack.Count; i++)
        {
            if (thenDealAutoAttack[i].name == _effect.name)
            {
                thenDealAutoAttack[i].value += _effect.value;
                thenDealAutoAttack[i].Activate();
                return;
            }
        }

        thenDealAutoAttack.Add(_effect);
        _effect.Activate();
    }

    #endregion 
    public int DealADDamage(int DMG)
    {
        if (!living) return -1;
        hp -= Mathf.Clamp(DMG - def,0,1000000);

        if (ally) BattleController.Instance.AddLog($"������{name}��{DMG - def}�̃_���[�W���󂯂�");
        else BattleController.Instance.AddLog($"�G��{name}��{DMG - def}�̃_���[�W���󂯂�");

        foreach (var AA in thenDealAutoAttack)
        {
            AA.Excute();
        }

        BattleController.Instance.WaitAnimation(AAAnim,AASound,ally,field);

        Dead();

        return DMG - def;
    }

    public int DealAPDamage(int DMG)
    {
        if (!living) return -1;
        hp -= Mathf.Clamp(DMG - res, 0, 1000000);

        if (ally) BattleController.Instance.AddLog($"������{name}��{DMG - res}�̃_���[�W���󂯂�");
        else BattleController.Instance.AddLog($"�G��{name}��{DMG - res}�̃_���[�W���󂯂�");

        foreach (var sk in thenDealSkill)
        {
            sk.Excute();
        }

        Dead();

        return DMG - res;
    }

    public int DealTrueDamage(int DMG)
    {
        if (!living) return -1;
        hp -= Mathf.Clamp(DMG, 0, 1000000);

        if (ally) BattleController.Instance.AddLog($"������{name}��{DMG}�̃_���[�W���󂯂�");
        else BattleController.Instance.AddLog($"�G��{name}��{DMG}�̃_���[�W���󂯂�");

        Dead();

        return DMG;
    }

    public void DealHeal(int Value)
    {
        if (!living) return;
        hp += Mathf.Clamp(Value, 0, maxHp);

        if (ally) BattleController.Instance.AddLog($"������{name}��{Value}�񕜂���");
        else BattleController.Instance.AddLog($"�G��{name}��{Value}�񕜂���");

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

        BattleController.Instance.StateUpdate();
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
