using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Symbol
{
    public string name;
    public string description;

    public List<int> activation;
    //public bool nowActive;

    public Sprite sprite;

    public void Activate(int level) { }
}

public class Glass : Symbol
{
    public Glass()
    {
        name = "草";
        description = "攻撃ごとのマナ回復量が(5/10/20)増える";
        activation = new List<int>() { 3, 4, 6 };
        //nowActive = false;

        sprite = Resources.Load<Sprite>("Symbol/Glass");
    }

    public void Activate(int level)
    {
        Debug.Log("草のシンボル(" + level + ")が発動中");

        for(int i=0;i < BattleController.Instance.allyField.Count; i++)
        {
            if(BattleController.Instance.allyField[i].no != 0 && BattleController.Instance.allyField[i].living)
            {
                switch (level) {
                    case 1:
                    BattleController.Instance.allyField[i].thenDealAutoAttack.Add(new RegenMana(true, BattleController.Instance.allyField[i].field,5));
                        break;
                    case 2:
                        BattleController.Instance.allyField[i].thenDealAutoAttack.Add(new RegenMana(true, BattleController.Instance.allyField[i].field, 10));
                        break;
                    case 3:
                        BattleController.Instance.allyField[i].thenDealAutoAttack.Add(new RegenMana(true, BattleController.Instance.allyField[i].field, 20));
                        break;
                }
            }
        }
    }
}