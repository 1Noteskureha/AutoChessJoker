using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler,IPointerEnterHandler
{   
    private Vector2 prevPos;
    public int no;

    [SerializeField]
    private TMPro.TMP_Text monsterName;
    [SerializeField]
    private Image monsterImage;
    [SerializeField]
    private Image monsterRank;
    [SerializeField]
    private List<Image> monsterSymbol;

    public bool canDrag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!canDrag) return;
        int tmp;
        if (no < 100) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (no + 1))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (no + 1))).rank - 1;
        else if (no < 103) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (no + 1 - 100))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (no + 1 - 100))).rank - 1;
        else if (no < 106) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (no + 1 - 103))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (no + 1 - 103))).rank - 1;
        else tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (no + 1 - 106))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (no + 1 - 106))).rank - 1;
        Home_Deck.Instance.InfomationUpdate(tmp);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        // ドラッグ前の位置を記憶しておく
        prevPos = transform.position;
        GetComponent<RectTransform>().anchoredPosition3D = new Vector3(GetComponent<RectTransform>().anchoredPosition3D.x, GetComponent<RectTransform>().anchoredPosition3D.y, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        // ドラッグ中は位置を更新する
        transform.position = eventData.position;
        GetComponent<RectTransform>().anchoredPosition3D = new Vector3(GetComponent<RectTransform>().anchoredPosition3D.x, GetComponent<RectTransform>().anchoredPosition3D.y, 0);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        // ドラッグ前の位置に戻す
        transform.position = prevPos;
        GetComponent<RectTransform>().anchoredPosition3D = new Vector3(GetComponent<RectTransform>().anchoredPosition3D.x, GetComponent<RectTransform>().anchoredPosition3D.y, 0);

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!canDrag) return;
        GetComponent<RectTransform>().anchoredPosition3D = new Vector3(GetComponent<RectTransform>().anchoredPosition3D.x, GetComponent<RectTransform>().anchoredPosition3D.y,0);
        //Debug.Log(gameObject.name + "に" + eventData.pointerDrag.name + "がドロップされました。");
        Home_Deck.Instance.InventorySwap(no, eventData.pointerDrag.GetComponent<DragAndDrop>().no);
    }

    public void Init(int _no)
    {
        no = _no;
        SetInfo();
    }

    public void SetInfo()
    {
        Monster monster;
        if (no >= 100)
        {   
            if(no < 103) monster = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (no + 1 - 100)));
            else if(no < 106) monster = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (no + 1 - 103)));
            else monster = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (no + 1 - 106)));
        }
        else
        {
            monster = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (no + 1)));
        }

        monsterName.text = monster.name;
        monsterImage.sprite = monster.sprite;
        switch (monster.rank)
        {
            case 1:
                monsterRank.sprite = Resources.Load<Sprite>("blank");
                break;
            case 2:
                monsterRank.sprite = Resources.Load<Sprite>("Rank/2");
                break;
            case 3:
                monsterRank.sprite = Resources.Load<Sprite>("Rank/3");
                break;
        }

        for(int i=0;i< monsterSymbol.Count; i++)
        {
            if(i < monster.symbol.Count)
            {
                monsterSymbol[i].sprite = monster.symbol[i].sprite;
            }
            else
            {
                monsterSymbol[i].sprite = Resources.Load<Sprite>("blank");
            }
        }
    }
}
