using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    int Score;
    int LifeKeys;
    int Gold;
    public static DataManager Instance;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        if(GameManager.Instance.firstTime == true && (!PlayerPrefs.HasKey("first") || PlayerPrefs.GetInt("first") != 10))
        {
            SetLifekeys(3);
            GameManager.Instance.firstTime = false;
            PlayerPrefs.SetInt("first", 10);
        }
        UpdateData();
        UpdateUI();
    }
    public void UpdateData()
    {
        Score = PlayerPrefs.GetInt("score");
        LifeKeys = PlayerPrefs.GetInt("life"); 
        if(!PlayerPrefs.HasKey("high"))
        {
            PlayerPrefs.SetInt("high", Score);
        }
        else
        {
            Gold = PlayerPrefs.GetInt("high");
            PlayerPrefs.SetInt("high", Score + Gold);
        }
        Gold = PlayerPrefs.GetInt("high");
        UpdateUI();
    }
    private void UpdateUI()
    {
        UIManager.Instance.UpdateUI(Score, GameManager.Instance.snakeLengthScore, Gold) ;
    }
    public void IncrementScore(int additionalScore)
    {
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + additionalScore);
    }

    public void IncrementLifeKeys(int additionalLifeKeys)
    {
        PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life") + additionalLifeKeys);
    }

    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public void SetLifekeys(int lifekeys)
    {
        PlayerPrefs.SetInt("life", lifekeys);
    }
    public int GetLifeKeysNum()
    {
        return PlayerPrefs.GetInt("life"); 
    }
        
    public void UseLifeKey()
    {
        PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life") - 1);
        UpdateUI();
    }
       

}
