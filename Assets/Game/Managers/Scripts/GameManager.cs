using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public int levelScore;
    [HideInInspector] public int snakeLengthScore;

    [HideInInspector] public bool canInput = true;

    public bool firstTime = false;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        canInput = false;
        snakeLengthScore = 1;
        DataManager.Instance.UpdateData();
    }
    
    public void Lose()
    {
        canInput = false; 
        UIManager.Instance.OpenLoseScreen(levelScore);
    }

    public void UseLifeKey()
    {
        canInput = true;
    }
        
}
