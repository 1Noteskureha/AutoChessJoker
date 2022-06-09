using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPick : MonoBehaviour
{

    //èÓïÒ
    [SerializeField]
    private Image iconSprite;
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private List<Image> symbolSprite;

    //ÉÇÉìÉXÉ^Å[
    [SerializeField]
    private GameObject monsterSample;
    [SerializeField]
    private Transform monsterContent;
    private List<GameObject> monsterList;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        description.text = "";
        monsterList = new List<GameObject>();

        for (int i = 0; i < 2; i++)
        {
            int no = (i + 1) * 1000;
            monsterList.Add(Instantiate(monsterSample, monsterContent));
            monsterList[i].GetComponent<ScrollMonster>().Init(this, no);
        }
    }

    private void OnEnable()
    {
        HomeController.Instance.TabButtonDisplay(false);
    }

    public void OnExit()
    {
        HomeController.Instance.TabButtonDisplay(true);
        this.gameObject.SetActive(false);
    }

    public void InfomationUpdate(Sprite sp, string des, List<Sprite> symbol)
    {
        iconSprite.sprite = sp;
        description.text = des;

        for (int i = 0; i < symbol.Count; i++)
        {
            if (i > symbol.Count)
            {
                symbolSprite[i].sprite = Resources.Load<Sprite>("blank");
            }
            else
            {
                symbolSprite[i].sprite = symbol[i];
            }
        }
    }


}
