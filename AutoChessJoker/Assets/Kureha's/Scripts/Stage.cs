using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string name;
    public string description;
    public List<List<int>> essense;
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
                name = "草原";
                description = "初心者向けダンジョン。草属性の敵が多く出現！";
                break;
        }
    }

    public void GenerateStage(int StageNo)
    {
        switch (StageNo)
        {
            case 1:
                enemyFields = new List<List<Monster>>()
                {
                    new List<Monster>() {new Blank(),new Slime(1), new Blank(), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Slime(1), new Slime(1), new Slime(1), new Blank(), new Blank(), new Blank() },
                    new List<Monster>() { new Slime(1), new Blank(), new Slime(1), new Slime(1), new Blank(), new Slime(1) },
                    new List<Monster>() { new Slime(1), new Slime(2), new Slime(1), new Slime(1), new Slime(1), new Slime(1) },
                };
                break;
        }
    }

    public void GenerateEssense(int StageNo)
    {
        switch (StageNo)
        {
            case 1:
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