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
