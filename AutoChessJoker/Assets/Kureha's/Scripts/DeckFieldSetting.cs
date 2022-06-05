using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckFieldSetting : MonoBehaviour
{
    [SerializeField]
    private List<DragAndDrop> dd;

    // Start is called before the first frame update
    void Start()
    {
        SetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        SetInfo();
    }

    public void SetInfo()
    {
        int i = 0;
        for (int no = 100; no < 110; no++,i++)
        {
            dd[i].Init(no);
        }
    }
}
