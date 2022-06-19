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
                name = "ハジマリ草原";
                description = "初心者向けダンジョン。草属性の優しい敵が多く出現";
                break;
            case 2:
                name = "タビダチ街道";
                description = "旅立ちに通る街道。獣・地属性の敵が出現";
                break;
            case 3:
                name = "ジョバン森";
                description = "序盤に立ち寄る森。初心者卒業の登竜門！";
                break;
            case 4:
                name = "コノサキ川";
                description = "少し危険な川渡り。水属性の敵が出現";
                break;
            case 5:
                name = "マジカル修道院";
                description = "魔法を学ぶ修道院。雷属性の敵が出現";
                break;
            case 6:
                name = "オソレ山";
                description = "少し険しい火山のふもと。ドラゴンなどが出現";
                break;
            case 7:
                name = "オソレ火山";
                description = "火山の山頂付近。炎属性の敵が出現";
                break;
            case 8:
                name = "アラサレ墓場";
                description = "何者かによって荒らされた墓場。冥属性の敵が出現";
                break;
        }
    }

    public void GenerateStage(int StageNo)
    {
        switch (StageNo)
        {
            case 1:
                //ハジマリ草原
                enemyFields = new List<List<Monster>>()
                {
                    new List<Monster>() { new Blank(),new Slime(1), new Blank(), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Goblin(1), new Blank(), new Goblin(1), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Slime(1), new Wolf(1), new Slime(1), new Blank(), new Goblin(1), new Blank() },
                };
                break;
            case 2:
                //タビダチ街道
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
            case 1:            //草,地,獣,炎,水,雷,空,死,聖
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