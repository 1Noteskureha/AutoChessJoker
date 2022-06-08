using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dict_Glossary : MonoBehaviour
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

        text.text = DataBase.DictYougo(no);
    }

    public void Display()
    {

        string description1 =
            "" +
            "";

        string description2 =
            "";

        parent.InfomationUpdate(Resources.Load<Sprite>("blank"), description1, description2, new List<Sprite>());
    }
}
