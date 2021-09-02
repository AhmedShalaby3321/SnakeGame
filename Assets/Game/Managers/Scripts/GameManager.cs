using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public int score;
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
    }
    
    public void Lose()
    {
        canInput = false; 
        UIManager.Instance.OpenLoseScreen(score);
    }

    public void UseLifeKey()
    {
        canInput = true;
    }
        
}
