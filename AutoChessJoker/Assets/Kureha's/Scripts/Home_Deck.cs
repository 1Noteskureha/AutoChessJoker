using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Deck : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> inventoryParent;
    [SerializeField]
    private TMPro.TMP_Text display;

    [SerializeField]
    private List<GameObject> inventory;

    int page = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInventoryPrevious()
    {
        if (page == 1) return;

        page--;
        for(int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);
        display.text = $"{page}/4";
    }

    public void OnInventoryNext()
    {
        Debug.Log(page);
        if (page == 4) return;

        page++;
        for (int i = 0; i < 4; i++)
        {
            inventoryParent[i].SetActive(false);
        }

        inventoryParent[page - 1].SetActive(true);
        display.text = $"{page}/4";
    }
}
