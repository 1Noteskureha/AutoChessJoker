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
            case 1:            //��,�n,�b,��,��,��,��,��,��
                essense = new List<List<int>>()
                {
                new List<int>() {5,0,0,0,0,0,0,0,0},
                new List<int>() {10,0,0,0,0,0,0,0,0},
                new List<int>() {10,0,0,0,0,0,0,0,0},
                new List<int>() {50,5,5,0,0,0,0,0,0},
                };
                break;
        }
    }
}