using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Symbol
{
    public string name;
    public string description;

    public List<int> activation;
    public int nowActive;
}

public class Glass : Symbol
{
    public Glass()
    {
        name = "��";
        description = "�U�����Ƃ̃}�i�񕜗ʂ�(5/10/20)������";
        activation = new List<int>() { 3, 4, 6 };
        nowActive = 0;
    }
}