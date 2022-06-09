using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleController : SingletonMonoBehaviour<BattleController>
{
    [SerializeField]
    private GameObject BattleField;

    //ステージと深度
    public Stage stage;

    [HideInInspector]
    public int progress;

    //オーバーレイ
    [SerializeField]
    private GameObject overrayStart;
    [SerializeField]
    private GameObject overrayContinue;
    [SerializeField]
    private GameObject overrayEnd;
    [SerializeField]
    private GameObject overrayLose;

    //ハンドル
    public List<Effect> first;
    public List<Effect> turnFirst;
    public List<Effect> turnEnd;

    public List<Monster> allyField;
    public List<Monster> enemyField;

    public List<Image> allyImage;
    public List<Image> enemyImage;

    public List<Slider> allyHP;
    public List<Slider> enemyHP;

    public List<Slider> allyMana;
    public List<Slider> enemyMana;

    public List<Image> allyRank;
    public List<Image> enemyRank;

    [SerializeField]
    private GameObject cutIn;

    //ログ関連
    [SerializeField]
    private GameObject logText;
    [SerializeField]
    private Transform content;

    private List<GameObject> log = new List<GameObject>();
    private Queue<int> spdQueue;     //0~5 = 味方、6~11 = 敵
    private Coroutine Turn;
    private ParticleSystem ps;

    public bool gameStop = true;

    // Start is called before the first frame update
    void Start()
    {
        BattleField.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Stage _stage)
    {
        stage = _stage;
        progress = 0;

        LogReset();

        //モンスター召喚
        SummonAllyMonsters();
        SummonEnemyMonsters();
        FieldUpdate();

        //シンボルの計算
        ActivationSymbol();
        StateUpdate();

        //最初のハンドル消化

        gameStop = true;
        overrayStart.SetActive(true);

        AddLog("Wave 1 スタート");
        Turn = StartCoroutine(TurnAction());
    }

    private void ActivationSymbol()
    {
        Dictionary<int,bool> CalcedMonster = new Dictionary<int,bool>();
        Dictionary<Symbol,int> CalcedSymbol = new Dictionary<Symbol,int>();


        for(int i=0;i< allyField.Count; i++)
        {               
            if (!CalcedMonster.ContainsKey(allyField[i].no))
            {
                CalcedMonster[allyField[i].no] = true;

                
                for(int j = 0; j < allyField[i].symbol.Count; j++)
                {
                    if (!CalcedSymbol.ContainsKey(allyField[i].symbol[j])) CalcedSymbol[allyField[i].symbol[j]] = 0;
                    CalcedSymbol[allyField[i].symbol[j]]++;
                }
            }
        }

        for(int i=1; i <= 4; i++)
        {
            if (!CalcedMonster.ContainsKey(PlayerPrefs.GetInt("Bt_Support" + i)))
            {
                CalcedMonster[PlayerPrefs.GetInt("Bt_Support" + i)] = true;

                for (int j = 0; j < DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + i)).symbol.Count; j++)
                {
                    if (!CalcedSymbol.ContainsKey(DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + i)).symbol[j])) CalcedSymbol[DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + i)).symbol[j]] = 0;
                    CalcedSymbol[DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Support" + i)).symbol[j]]++;
                }
            }
        }

        foreach(var sb in CalcedSymbol)
        {
            for(int i = sb.Key.activation.Count; i > 0; i--)
            {
                if(CalcedSymbol[sb.Key] >= sb.Key.activation[i - 1])
                {
                    sb.Key.Activate(i);
                    break;
                }
            }
        }

    }

    private void LogReset()
    {
        foreach(var l in log)
        {
            Destroy(l);
        }

        log = new List<GameObject>();
    }

    public void AddLog(string s)
    {
        var add = Instantiate(logText, content);

        add.GetComponent<TMP_Text>().text = $"{log.Count + 1}: {s}";

        log.Add(add);
    }

    private IEnumerator TurnAction()
    {
        int t = 1;//無限ループ防止
        while (t < 1000)
        {
            while (gameStop) {
                yield return new WaitForSeconds(0.1f);
            }

            //カットイン
            cutIn.GetComponent<TMP_Text>().text = "ターン" + t;
            cutIn.SetActive(true);;

            yield return new WaitForAnimation(cutIn.GetComponent<Animator>());

            cutIn.SetActive(false);
            

            //ターン初めのハンドル消化

            //行動順計算
            SpdDecide();

            //行動順に行動
            while (!AllDone() && t <1000)
            {

                while (gameStop)
                {
                    yield return new WaitForSeconds(0.1f);
                }

                if (spdQueue.Count == 0) break;
                int target = spdQueue.Dequeue();

                //Debug.Log(target);

                if (target < 6)
                {
                    allyField[target].Move();
                }
                else
                {
                    enemyField[target - 6].Move();
                }
                //t++;

                yield return new WaitForSeconds(0.5f);

                if (ps != null)
                {
                    while (ps.isPlaying)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                }

                ps = null;
            }


            //ターン終了時のハンドル消化

            //リフレッシュ
            for(int i=0;i<allyField.Count;i++){
                allyField[i].Refresh();
            }
            for (int i = 0; i < enemyField.Count; i++)
            {
                enemyField[i].Refresh();
            }

            t++;
        }

        yield break;
    }

    //行動が済んでいるか判定
    private bool AllDone()
    {
        foreach (var enemy in enemyField)
        {
            //Debug.Log(enemy.done);
            if (!enemy.done) return false;
        }
        foreach (var ally in allyField)
        {
            if (!ally.done) return false;
        }

        return true;
    }

    //行動順計算
    private void SpdDecide()
    {
        spdQueue = new Queue<int>();
        List<Monster> monsters = new List<Monster>();
        
        foreach (var ally in allyField)
        {
            if (ally.no != 0)
                monsters.Add(ally);

        }
        foreach (var enemy in enemyField)
        {
            if(enemy.no != 0)
                monsters.Add(enemy);

        }


        int max = -1;
        int _ally = 0;
        int position = 0;
        List<bool> calced = new List<bool>();

        for(int i = 0; i < monsters.Count; i++)
        {
            calced.Add(false);
        }

        for (int j = 0; j < monsters.Count; j++)
        {
            max = -1;
            int tmp = -1;
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].spd > max && !monsters[i].done && !calced[i])
                {
                    //Debug.Log("Yeah");
                    max = monsters[i].spd;
                    if (monsters[i].ally)
                    {
                        _ally = 0;
                    }
                    else
                    {
                        _ally = 6;
                    }

                    position = monsters[i].field;
                    tmp = i;
                }
            }
            

            if (tmp == -1) return;
            calced[tmp] = true;
            spdQueue.Enqueue(_ally + position);
        }

        //Debug.Log(spdQueue.Count);
    }

    public void MonsterDead(bool ally,int field)
    {   

        if (ally) AddLog("味方の" + allyField[field].name + "(" + allyField[field].field + ")は倒れた");
        else AddLog("敵の" + enemyField[field].name + "(" + allyField[field].field + ")は倒れた");
        

        if (ally)
        {
            allyField[field].sprite = Resources.Load<Sprite>("Monster/blank");


            if (allyField[0].living == false && allyField[1].living == false && allyField[2].living == false && allyField[3].living == false && allyField[4].living == false && allyField[5].living == false)
            {
                GameOver();
                return;
            }
            if(allyField[0].living == false && allyField[1].living == false && allyField[2].living == false)
            {   
                for(int i = 0; i < 3; i++)
                {
                    var tmp = allyField[i];
                    var tmp2 = allyField[i].field;
                    allyField[i] = allyField[i + 3];
                    allyField[i + 3] = tmp;
                    allyField[i].field = allyField[i + 3].field;
                    allyField[i + 3].field = tmp2;
                }
            }
        }
        else
        {
            enemyField[field].sprite = Resources.Load<Sprite>("Monster/blank");

            if (enemyField[0].living == false && enemyField[1].living == false && enemyField[2].living == false && enemyField[3].living == false && enemyField[4].living == false && enemyField[5].living == false)
            {
                Clear();
                return;
            }
            if (enemyField[0].living == false && enemyField[1].living == false && enemyField[2].living == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    var tmp = enemyField[i];
                    var tmp2 = enemyField[i].field;
                    enemyField[i] = enemyField[i + 3];
                    enemyField[i + 3] = tmp;
                    enemyField[i].field = enemyField[i + 3].field;
                    enemyField[i + 3].field = tmp2;
                }
            }
        }

        FieldUpdate();
        StateUpdate();
        SpdDecide();
    }

    public void StateUpdate()
    {
        for(int i = 0; i < 6; i++)
        {
            if (allyField[i].living)
            {
                allyHP[i].gameObject.SetActive(true);
                allyMana[i].gameObject.SetActive(true);
            }
            else
            {                
                allyHP[i].gameObject.SetActive(false);
                allyMana[i].gameObject.SetActive(false);

            }
            allyHP[i].maxValue = allyField[i].maxHp;
            allyHP[i].value = allyField[i].hp;
            allyMana[i].maxValue = allyField[i].maxMana;
            allyMana[i].value = allyField[i].mana;

            if (enemyField[i].living)
            {
                enemyHP[i].gameObject.SetActive(true);
                enemyMana[i].gameObject.SetActive(true);
            }
            else
            {
                enemyHP[i].gameObject.SetActive(false);
                enemyMana[i].gameObject.SetActive(false);
            }
            enemyHP[i].maxValue = enemyField[i].maxHp;
            enemyHP[i].value = enemyField[i].hp;
            enemyMana[i].maxValue = enemyField[i].maxMana;
            enemyMana[i].value = enemyField[i].mana;
        }
    }
    
    //全滅
    private void GameOver()
    {
        StopCoroutine(Turn);
        //戻る
        overrayLose.SetActive(true);
    }

    //敵全滅(ステージクリア)
    private void Clear()
    {
        AddLog("ステージ" + progress + "クリア");
        //エッセンス獲得
        GetEssense();

        StopCoroutine(Turn);

        progress++;

        if(progress == stage.enemyFields.Count)
        {
            //アンロック
            //戻る

            overrayEnd.SetActive(true);
            return;
        }

        SummonAllyMonsters();
        SummonEnemyMonsters();
        FieldUpdate();
        StateUpdate();
        LogReset();

        AddLog($"Wave {progress + 1} スタート");

        gameStop = true;
        overrayContinue.SetActive(true);

        Turn = StartCoroutine(TurnAction());
    }

    private void GetEssense()
    {
        PlayerPrefs.SetInt("Essense_A",PlayerPrefs.GetInt("Essense_A") + stage.essense[progress][0]);
        PlayerPrefs.SetInt("Essense_B",PlayerPrefs.GetInt("Essense_B") + stage.essense[progress][1]);
        PlayerPrefs.SetInt("Essense_C",PlayerPrefs.GetInt("Essense_C") + stage.essense[progress][2]);
        PlayerPrefs.SetInt("Essense_D",PlayerPrefs.GetInt("Essense_D") + stage.essense[progress][3]);
        PlayerPrefs.SetInt("Essense_E",PlayerPrefs.GetInt("Essense_E") + stage.essense[progress][4]);
        PlayerPrefs.SetInt("Essense_F",PlayerPrefs.GetInt("Essense_F") + stage.essense[progress][5]);
        PlayerPrefs.SetInt("Essense_G",PlayerPrefs.GetInt("Essense_G") + stage.essense[progress][6]);
        PlayerPrefs.SetInt("Essense_H",PlayerPrefs.GetInt("Essense_H") + stage.essense[progress][7]);
        PlayerPrefs.SetInt("Essense_I",PlayerPrefs.GetInt("Essense_I") + stage.essense[progress][8]);
    }

    //戦闘初めに味方モンスターの召喚
    private void SummonAllyMonsters()
    {
        allyField = new List<Monster>();
        //allyMonsters = new List<Monster>();

        for(int i=0;i<6;i++)
        {
            allyField.Add(new Blank());
        }

        for(int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt("Bt_Front" + (i + 1)) != 0)
            {
                allyField[i] = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Front" + (i+1)));
                allyField[i].ally = true;
                allyField[i].field = i;

                allyImage[i].sprite = allyField[i].sprite;
            }
            if (PlayerPrefs.GetInt("Bt_Back" + (i + 1)) != 0)
            {
                allyField[i + 3] = DataBase.Bt_noToMonster(PlayerPrefs.GetInt("Bt_Back" + (i + 1)));
                allyField[i + 3].ally = true;
                allyField[i + 3].field = i+3;

                allyImage[i + 3].sprite = allyField[i].sprite;
            }
        }

        //FieldUpdate();
    }

    private void SummonEnemyMonsters()
    {
        enemyField = new List<Monster>();
        //enemyMonsters = new List<Monster>();

        for(int i=0;i<6;i++)
        {
            enemyField.Add(new Blank());
            enemyImage[i].sprite = enemyField[i].sprite;
        }

        for (int i = 0; i < 6; i++)
        {
            //enemyMonsters.Add(stage.enemyFields[progress][i]);
            enemyField[i] = stage.enemyFields[progress][i];
            enemyField[i].ally = false;
            enemyField[i].field = i;
            enemyImage[i].sprite = enemyField[i].sprite;

            if (PlayerPrefs.GetInt("Dict_Unlock" + enemyField[i].no,0) == 0) PlayerPrefs.SetInt("Dict_Unlock" + enemyField[i].no, 1);
        }

        //FieldUpdate();
    }

    private void FieldUpdate()
    {
        for (int i = 0; i < 6; i++)
        {   
            
            float size;

            allyImage[i].sprite = allyField[i].sprite;
            allyImage[i].SetNativeSize();
            
            if(allyImage[i].rectTransform.sizeDelta.x > allyImage[i].rectTransform.sizeDelta.y) size = allyImage[i].rectTransform.sizeDelta.x;
            else size = allyImage[i].rectTransform.sizeDelta.y;
            if (size < 100) allyImage[i].rectTransform.sizeDelta = new Vector2(allyImage[i].rectTransform.sizeDelta.x * (100 / size), allyImage[i].rectTransform.sizeDelta.y * (100 / size));

            
            //Rank
            switch (allyField[i].rank)
            {
                case 1:
                    allyRank[i].sprite = Resources.Load<Sprite>("blank");
                    break;
                case 2:
                    allyRank[i].sprite = Resources.Load<Sprite>("rank/2");
                    allyRank[i].rectTransform.sizeDelta = new Vector2(20, 20);
                    
                    break;
                case 3:
                    allyRank[i].sprite = Resources.Load<Sprite>("rank/3");
                    allyRank[i].rectTransform.sizeDelta = new Vector2(30, 30);
                    break;
            }
            if(!allyField[i].living) allyRank[i].sprite = Resources.Load<Sprite>("blank");

            enemyImage[i].sprite = enemyField[i].sprite;
            enemyImage[i].SetNativeSize();

            if (enemyImage[i].rectTransform.sizeDelta.x > enemyImage[i].rectTransform.sizeDelta.y) size = enemyImage[i].rectTransform.sizeDelta.x;
            else size = enemyImage[i].rectTransform.sizeDelta.y;
            if (size < 100) enemyImage[i].rectTransform.sizeDelta = new Vector2(enemyImage[i].rectTransform.sizeDelta.x * (100 / size), enemyImage[i].rectTransform.sizeDelta.y * (100 / size));

            switch (enemyField[i].rank)
            {
                case 1:
                    enemyRank[i].sprite = Resources.Load<Sprite>("blank");
                    break;
                case 2:
                    enemyRank[i].sprite = Resources.Load<Sprite>("rank/2");
                    enemyRank[i].rectTransform.sizeDelta = new Vector2(20, 20);

                    break;
                case 3:
                    enemyRank[i].sprite = Resources.Load<Sprite>("rank/3");
                    enemyRank[i].rectTransform.sizeDelta = new Vector2(30, 30);
                    break;
            }
            if (!enemyField[i].living) enemyRank[i].sprite = Resources.Load<Sprite>("blank");
        }
    }

    public void WaitAnimation(GameObject anim,AudioClip ac,bool ally,int field)
    {
        if (ally) ps = Instantiate(anim, allyImage[field].transform).GetComponent<ParticleSystem>();
        else ps = Instantiate(anim, enemyImage[field].transform).GetComponent<ParticleSystem>();
        ps.Play();

        AudioPlayer.Instance.SEPlay(ac);
    }

    public void OnContinue()
    {
        gameStop = false;
        overrayStart.SetActive(false);
        overrayContinue.SetActive(false);
    }

    public void OnEnd()
    {
        gameStop = true;
        overrayLose.SetActive(false);
        overrayEnd.SetActive(false);
        overrayStart.SetActive(false);
        overrayContinue.SetActive(false);

        BattleField.SetActive(false);
    }
}
