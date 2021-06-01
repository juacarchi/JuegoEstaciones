using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> estacionList;
    public List<GameObject> principalEstacionList;
    public GameObject fx_Stars;
    public GameObject fx_Succes;
    public int levelsCompleted;
    bool levelComplete;
    float timer = 1.5f;
    bool TimeToEnd;
    bool allLevelsCompleted;
    int lastSeason;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            principalEstacionList = new List<GameObject>(estacionList);
        }
        else
        {
            Destroy(this.gameObject);
        }
        lastSeason = 10;
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimeToEnd)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1.5f;
                TimeToEnd = false;
            }
        }
    }
    public void SetLevelsCompleted(int levelsCompleted)
    {
        this.levelsCompleted = levelsCompleted;
    }
    public int GetLevelsCompleted()
    {
        return levelsCompleted;
    }
    public void SetLevelComplete(bool levelComplete)
    {
        this.levelComplete = levelComplete;
    }
    public bool GetLevelComplete()
    {
        return levelComplete;
    }
    public void SumaNivel()
    {
        levelsCompleted++;
        SetLevelComplete(true);
    }
    public List<GameObject> GetEstacionList()
    {
        return estacionList;
    }
    public void SetEstacionList(List<GameObject> estacionList)
    {
        this.estacionList = estacionList;
    }
    public bool GetAllLevelsCompleted()
    {
        return allLevelsCompleted;
    }
    public void ResetAllLevelsCompleted(bool allLevelsCompleted)
    {
        this.allLevelsCompleted = allLevelsCompleted;
    }
    public void SetLastSeason(int lastSeason)
    {
        this.lastSeason = lastSeason;
    }
    public int GetLastSeason()
    {
        return this.lastSeason;
    }
}
