using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbolFire : Symbol
{
    public symbolFire()
    {
        name = "��";
        description = "�퓬�J�n������ɉ����^����(10/20/60)�B\n" +
                      "����͍U���͂������^�[���J�n���Ƀ_���[�W��^����B";
        activation = new List<int>() { 2, 4, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/fire");
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
                        BattleController.Instance.enemyField[i].addTurnFirst(new OnFire(false, BattleController.Instance.enemyField[i].field, 10));
                        break;
                    case 2:
                        BattleController.Instance.enemyField[i].addTurnFirst(new OnFire(false, BattleController.Instance.enemyField[i].field, 20));
                        break;
                    case 3:
                        BattleController.Instance.enemyField[i].addTurnFirst(new OnFire(false, BattleController.Instance.enemyField[i].field, 60));
                        break;
                }
            }
        }
    }    
}
