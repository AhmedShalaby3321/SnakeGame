using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Range(0,100)]
    public float EnemiesPercentage;
    [HideInInspector] public bool canInput = true;
    public bool isSpline = true;
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
        UIManager.Instance.OpenLoseScreen();
    }

    public void UseLifeKey()
    {
        canInput = true;
    }
        
}
