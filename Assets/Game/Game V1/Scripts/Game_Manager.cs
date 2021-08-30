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
            rb.velocity = Vector3.zero;
            GameOverUI.SetActive(true);
        }
    }

    void Restart()
    {
        SnakeBehaviour.lives = 5;
        SnakeBehaviour.score = 0;
        SceneManager.LoadScene("SnakeGame");
    }

}
