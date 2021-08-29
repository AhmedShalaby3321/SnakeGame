using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    bool gameEnded = false;
    public Rigidbody rb;
    public GameObject GameOverUI;
    private void Start()
    {
        GameOverUI.SetActive(false);
        
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            Debug.Log("Rst");
            Restart();
        }
    }
    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("GAMEEE OVERRRRR !!!!");
            rb.velocity = Vector3.zero;
            GameOverUI.SetActive(true);
        }
    }

    void Restart()
    {
        Debug.Log("Restaarrttt !!!!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Move_Snake.ForwardSpeed = 7f;
        Move_Snake.SidesSpeed = 5f;
        Tree_Friend.lives = 5;
        Tree_Friend.score = 0;
        SceneManager.LoadScene("SnakeGame");
    }

}
