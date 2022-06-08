using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dict_Symbol : MonoBehaviour
{
    private DictSetting parent;
    private int no;

    [SerializeField]
    private TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(DictSetting ds, int _no)
    {
        parent = ds;
        no = _no;

        text.text = DataBase.DictSymbol(no).name;
    }

    public void Display()
    {
        Symbol symbol = DataBase.DictSymbol(no);

        string description1 =
            symbol.name +
            "\n" +
            "\n" +
            symbol.description;

        string description2 =
            "éùÇ¡ÇƒÇÈÉÇÉìÉXÉ^Å[";

        parent.InfomationUpdate(symbol.sprite, description1, description2,new List<Sprite>());
    }
}
