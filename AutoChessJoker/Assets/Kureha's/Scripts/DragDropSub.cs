using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSub : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private InventoryPick parent;

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
        int no = GetComponent<DragAndDrop>().no;
        int tmp;
        if (no < 100) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (no + 1))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Inventory_Monster" + (no + 1))).rank - 1;
        else if (no < 103) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (no + 1 - 100))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (no + 1 - 100))).rank - 1;
        else if (no < 106) tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (no + 1 - 103))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (no + 1 - 103))).rank - 1;
        else tmp = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (no + 1 - 106))).no + DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + (no + 1 - 106))).rank - 1;
        parent.InfomationUpdate(tmp);
    }

}
