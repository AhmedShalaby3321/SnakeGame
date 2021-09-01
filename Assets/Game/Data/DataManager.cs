using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //[SerializeField] DataToSave data;
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
        //data.Score = 0;
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
        Score = PlayerPrefs.GetInt("score");// data.Score;
        LifeKeys = PlayerPrefs.GetInt("life"); //data.lifeKeysNum;
        UpdateUI();
        if(!PlayerPrefs.HasKey("high"))
        {
            //data.HighScore = Score;
            PlayerPrefs.SetInt("high", Score);
        }
        else
        {
            Gold = PlayerPrefs.GetInt("high");
            PlayerPrefs.SetInt("high", Score + Gold);
        }
        Gold = PlayerPrefs.GetInt("high");
        //data.Score = 0;
    }
    private void UpdateUI()
    {
        UIManager.Instance.UpdateUI(Score, LifeKeys,Gold);
    }
    public void IncrementScore(int additionalScore)
    {
        //data.Score += additionalScore;

        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + additionalScore);
    }

    public void IncrementLifeKeys(int additionalLifeKeys)
    {
        //data.lifeKeysNum += additionalLifeKeys;
        PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life") + additionalLifeKeys);
    }

    public void SetScore(int score)
    {
        //data.Score = score;
        PlayerPrefs.SetInt("score", score);
    }

    public void SetLifekeys(int lifekeys)
    {
        //data.lifeKeysNum = lifekeys;
        PlayerPrefs.SetInt("life", lifekeys);
    }
    public int GetLifeKeysNum()
    {
        return PlayerPrefs.GetInt("life"); //data.lifeKeysNum;
    }
        
    public void UseLifeKey()
    {
        //data.lifeKeysNum--;
        PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life") - 1);
        UpdateUI();
    }
       

}
