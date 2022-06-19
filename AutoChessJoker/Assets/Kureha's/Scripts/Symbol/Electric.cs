using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : Symbol
{
    public Electric()
    {
        name = "��";
        description = "���肪�s�����邽�сA����ɖ�Ⴢ�(10/20)�^����B�B\n" +
                      "��Ⴢ�100���܂�ƍs���s�\�ɂȂ�B";
        activation = new List<int>() { 3, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/electric");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("���̃V���{��(" + level + ")��������");

        for (int i = 0; i < BattleController.Instance.enemyField.Count; i++)
        {
            if (BattleController.Instance.enemyField[i].no != 0 && BattleController.Instance.enemyField[i].living)
            {
                switch (level)
                {
                    case 1:
                        BattleController.Instance.enemyField[i].addTurnEnd(new Taiden(false, BattleController.Instance.enemyField[i].field, 10));
                        break;
                    case 2:
                        BattleController.Instance.enemyField[i].addTurnEnd(new Taiden(false, BattleController.Instance.enemyField[i].field, 20));
                        break;
                }
            }
        }
    }
}
