using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string name;
    public string description;
    public List<List<int>> essense;
    public Sprite sprite;
    //public Sprite sprite;
    public int no;

    private const int Max_Stage = 2;

    public List<List<Monster>> enemyFields;

    public Stage(int no)
    {
        GenerateName(no);
        GenerateEssense(no);
        GenerateStage(no);
    }

    public void GenerateName(int StageNo)
    {
        switch (StageNo)
        {
            case 1:
                name = "�n�W�}������";
                description = "���S�Ҍ����_���W�����B�������̗D�����G�������o��";
                break;
            case 2:
                name = "�^�r�_�`�X��";
                description = "�������ɒʂ�X���B�b�E�n�����̓G���o��";
                break;
            case 3:
                name = "�W���o���X";
                description = "���Ղɗ������X�B���S�ґ��Ƃ̓o����I";
                break;
            case 4:
                name = "�R�m�T�L��";
                description = "�����댯�Ȑ�n��B�������̓G���o��";
                break;
            case 5:
                name = "�}�W�J���C���@";
                description = "���@���w�ԏC���@�B�������̓G���o��";
                break;
            case 6:
                name = "�I�\���R";
                description = "�����������ΎR�̂ӂ��ƁB�h���S���Ȃǂ��o��";
                break;
            case 7:
                name = "�I�\���ΎR";
                description = "�ΎR�̎R���t�߁B�������̓G���o��";
                break;
            case 8:
                name = "�A���T�����";
                description = "���҂��ɂ���čr�炳�ꂽ���B�������̓G���o��";
                break;
        }
    }

    public void GenerateStage(int StageNo)
    {
        switch (StageNo)
        {
            case 1:
                //�n�W�}������
                enemyFields = new List<List<Monster>>()
                {
                    new List<Monster>() { new Blank(),new Slime(1), new Blank(), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Goblin(1), new Blank(), new Goblin(1), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Slime(1), new Wolf(1), new Slime(1), new Blank(), new Goblin(1), new Blank() },
                };
                break;
            case 2:
                //�^�r�_�`�X��
                enemyFields = new List<List<Monster>>()
                {
                    new List<Monster>() { new Cobolt(1),new GoblinAxe(1), new Cobolt(1), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Slime(1), new WereWolf(1), new Cobolt(1), new Blank(), new GoblinMage(1), new Blank() },
                    new List<Monster>() { new Blank(), new Dragon(1), new GoblinThief(1), new GoblinMage(1), new Blank(), new Blank() },
                };
                break;
        }
    }

    public void GenerateEssense(int StageNo)
    {
        switch (StageNo)
        {
            case 1://�n�W�}������ ��,�n,�b,��,��,��,��,��,��
                essense = new List<List<int>>()
                {
                new List<int>() {5,0,0,0,0,0,0,0,0},
                new List<int>() {5,0,0,0,0,0,0,0,0},
                new List<int>() {20,10,10,0,0,0,0,0,0},
                };
                break;
            case 2://�^�r�_�`�X��
                essense = new List<List<int>>()
                {
                    new List<int>() {0,5,5,0,0,0,0,0,0},
                    new List<int>() {0,10,10,0,0,0,0,0,0},
                    new List<int>() {10,25,25,0,0,0,10,0,0},
                };
                break;
            case 3://�W���o���X
                essense = new List<List<int>>()
                {
                    new List<int>() {10,0,0,0,0,0,0,0,0},
                    new List<int>() {20,10,0,0,0,0,0,0,0},
                    new List<int>() {50,20,0,0,0,0,10,0,0},
                };
                break;
            case 4://�R�m�T�L��
                essense = new List<List<int>>()
                {
                    new List<int>() {0,0,5,0,10,0,5,0,0},
                    new List<int>() {0,0,5,0,10,0,5,0,0},
                    new List<int>() {0,0,5,0,10,0,5,0,0},
                    new List<int>() {0,0,30,0,70,0,20,0,0},
                };
                break;
            case 5://�}�W�J���C���@
                essense = new List<List<int>>()
                {
                    new List<int>() {0,5,0,10,0,15,0,0,10},
                    new List<int>() {0,5,0,10,0,15,0,0,10},
                    new List<int>() {0,5,0,10,0,15,0,0,10},
                    new List<int>() {0,10,0,30,0,80,0,0,30},
                };
                break;
            case 6://�I�\���R
                essense = new List<List<int>>()
                {
                    new List<int>() {0,10,10,10,0,0,20,0,0},
                    new List<int>() {0,10,10,10,0,0,20,0,0},
                    new List<int>() {0,10,10,10,0,0,20,0,0},
                    new List<int>() {0,60,60,30,0,0,80,0,0},
                };
                break;
            case 7://�I�\���ΎR
                essense = new List<List<int>>()
                {
                    new List<int>() {0,10,0,20,0,0,5,0,0},
                    new List<int>() {0,10,0,20,0,0,5,0,0},
                    new List<int>() {0,10,0,20,0,0,5,0,0},
                    new List<int>() {0,60,0,100,0,0,80,0,0},
                };
                break;
            case 8://�A���T�����
                essense = new List<List<int>>()
                {
                    new List<int>() {0,0,0,10,0,0,10,30,0},
                    new List<int>() {0,0,0,10,0,0,10,30,0},
                    new List<int>() {0,0,0,10,0,0,10,30,0},
                    new List<int>() {0,0,0,60,0,0,80,150,0},
                };
                break;
        }
    }

    public bool Unlock()
    {
        if(no < PlayerPrefs.GetInt("Stage_Clear"))
        {   
            if(no < Max_Stage)
            PlayerPrefs.SetInt("Stage_Unlock",no + 1);

            PlayerPrefs.SetInt("Stage_Clear", no);

            return true;
        }

        return false;
    }
}