using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holy : Symbol
{
    public Holy()
    {
        name = "��";
        description = "���S���A��x����HP�}�b�N�X�ŕ�������";
        activation = new List<int>() { 8 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/holy");
    }

    public new void Activate(int level)
    {
        BattleController.Instance.AddLog("���̃V���{��(" + level + ")��������");

        for (int i = 0; i < BattleController.Instance.allyField.Count; i++)
        {
            if (BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                BattleController.Instance.allyField[i].addThenDead(new Resurrection(true, BattleController.Instance.allyField[i].field, 1));
            }
        }
    }
}
