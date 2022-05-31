using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{

    [SerializeField]
    private GameObject Deck;
    [SerializeField]
    private GameObject Battle;
    [SerializeField]
    private GameObject Summon;

    [SerializeField]
    private GameObject BattleField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StateReset()
    {
        Deck.SetActive(false);
        Battle.SetActive(false);
        Summon.SetActive(false);
    }

    public void OnPressDeck()
    {
        if (Deck.activeSelf) return;
        StateReset();
        Deck.SetActive(true);
    }

    public void OnPressBattle()
    {
        if (Battle.activeSelf) return;
        StateReset();
        Battle.SetActive(true);
    }

    public void OnPressSummon()
    {
        if (Summon.activeSelf) return;
        StateReset();
        Summon.SetActive(true);
    }
}
