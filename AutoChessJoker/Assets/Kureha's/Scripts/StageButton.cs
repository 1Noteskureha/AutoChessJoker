using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text StageName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int Selected)
    {   
        
        GetComponent<Button>().onClick.AddListener(() => Home_Battle.Instance.OnSelectStage(Selected));
    }
}
