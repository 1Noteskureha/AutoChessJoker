using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Home_Summon : MonoBehaviour
{
    [SerializeField]
    private GameObject Summon;
    [SerializeField]
    private GameObject Match;
    [SerializeField]
    private GameObject Evolve;
    [SerializeField]
    private GameObject Delete;

    [SerializeField]
    private List<TMP_Text> essense;

    // Start is called before the first frame update
    void Start()
    {
        EssenseUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSummon()
    {
        Summon.SetActive(true);
        Match.SetActive(false);
        Evolve.SetActive(false);
        Delete.SetActive(false);
    }

    public void OnMatch()
    {
        Summon.SetActive(false);
        Match.SetActive(true);
        Evolve.SetActive(false);
        Delete.SetActive(false);
    }

    public void OnEvolve()
    {
        Summon.SetActive(false);
        Match.SetActive(false);
        Evolve.SetActive(true);
        Delete.SetActive(false);
    }

    public void OnDelete()
    {
        Summon.SetActive(false);
        Match.SetActive(false);
        Evolve.SetActive(false);
        Delete.SetActive(true);
    }

    public void OnEnable()
    {
        EssenseUpdate();
    }

    private void EssenseUpdate()
    {
        essense[0].text = $"{PlayerPrefs.GetInt("Essense_A")}";
        essense[1].text = $"{PlayerPrefs.GetInt("Essense_B")}";
        essense[2].text = $"{PlayerPrefs.GetInt("Essense_C")}";
        essense[3].text = $"{PlayerPrefs.GetInt("Essense_D")}";
        essense[4].text = $"{PlayerPrefs.GetInt("Essense_E")}";
        essense[5].text = $"{PlayerPrefs.GetInt("Essense_F")}";
        essense[6].text = $"{PlayerPrefs.GetInt("Essense_G")}";
        essense[7].text = $"{PlayerPrefs.GetInt("Essense_H")}";
        essense[8].text = $"{PlayerPrefs.GetInt("Essense_I")}";
    }
}
