using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Feedback")]
    [SerializeField] MMFeedbacks scoreFeedback;

    [Header("Gameplay Screen")]
    [SerializeField] Image gameplayscreen;
    [SerializeField] TextMeshProUGUI LevelScore;
    [SerializeField] TextMeshProUGUI SnakeLengthScore;

    //[SerializeField] TextMeshProUGUI LifeKeysTxt;
    //[SerializeField] public Image PowerUpImage;
    //[SerializeField] public Image PowerUpTimer;

    [Header("Home Screen")]
    [SerializeField] Text HighScore;

    [Header("Pause/Settings Screen")]
    [SerializeField] AudioListener AudioListener;
    [SerializeField] Toggle soundToggle;

    [Header("Lose Screen")]
    [SerializeField] Image LoseScreen;
    [SerializeField] TextMeshProUGUI LoseScore;
    //[SerializeField] Button lifekeys;

    [HideInInspector] public float timer;
    [HideInInspector] public bool hasPowerUp;


    float currentTime = 0;

    public static UIManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //PowerUpImage.gameObject.SetActive(false);
    }

    //private void Update()
    //{
    //    if (hasPowerUp)
    //        FillTimer(timer);
    //    else if(currentTime > 0)
    //        currentTime = 0;
    //}

    public void testButton()
    {
        Debug.Log("clicked");
    }
    public void StartGame()
    {
        GameManager.Instance.canInput = true;
    }
    public void UpdateUI(int score, int lengthScore, int highscore)
    {
        scoreFeedback.PlayFeedbacks();
        LevelScore.text = score.ToString();
        SnakeLengthScore.text = lengthScore.ToString();
        HighScore.text = highscore.ToString();
    }

    public void ToggleSound()
    {
        AudioListener.enabled = soundToggle.isOn;
    }

    public void Pause()
    {
        GameManager.Instance.canInput = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        GameManager.Instance.canInput = true;
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
    public void UseLifeKey()
    {
        gameplayscreen.gameObject.SetActive(true);
        DataManager.Instance.UseLifeKey();
        GameManager.Instance.UseLifeKey();
    }

    public void OpenLoseScreen(int score)
    {
        gameplayscreen.gameObject.SetActive(false);
        LoseScreen.gameObject.SetActive(true);
        LoseScore.text = score.ToString();
        //lifekeys.interactable = (DataManager.Instance.GetLifeKeysNum() > 0);
    }

    public void FillTimer(float time)
    {
        currentTime += Time.deltaTime;
        //PowerUpTimer.fillAmount =  ((currentTime  / time));
    }

    public void  startPowerUp(Sprite sprite, float coolDownTime)
    {
       // PowerUpImage.transform.parent.gameObject.SetActive(true);
       // PowerUpImage.gameObject.SetActive(true);
       //PowerUpImage.sprite = sprite;
       timer = coolDownTime;
       hasPowerUp = true;
    }

    public void endPowerUp()
    {
        //PowerUpImage.transform.parent.gameObject.SetActive(false);
        //PowerUpImage.gameObject.SetActive(false);
       hasPowerUp = false;
    }


}
