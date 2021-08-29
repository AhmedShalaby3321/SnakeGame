using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tree_Friend : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skmrd;
    public Text liveText;
    public Text scoreText;
    const int maxLives = 5;
    public static int lives;
    public static int score;
    int collisionCounter;
    int maxCounter = 5;

    public Game_Manager game_Manager;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
        liveText.text = lives.ToString();
        score = 0;
        scoreText.text = score.ToString();
        collisionCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
       
       // other.GetComponent<SkinnedMeshRenderer>().enabled = false;
        if (other.CompareTag("F_Heart"))
        {
                other.GetComponent<Renderer>().enabled = false;
                if (lives < maxLives)
            {
                lives++;
                liveText.text = lives.ToString();
            }
           
        }
      
        if (other.CompareTag("E_Bomb"))
        {
            other.GetComponent<Renderer>().enabled = false;
            // this.GetComponent<Renderer>().enabled = false;
            skmrd.GetComponent<SkinnedMeshRenderer>().enabled = false;
            Invoke("Appear", 2f);
        }

        if(other.CompareTag("Balls"))
        {
            other.GetComponent<Renderer>().enabled = false;
            //if (this.GetComponent<Renderer>().material.color == other.GetComponent<Renderer>().material.GetColor("_Color"))
            if (skmrd.GetComponent<SkinnedMeshRenderer>().material.color == other.GetComponent<Renderer>().material.GetColor("_Color"))
            {
                if (score > 0)
                {
                    score--;
                    scoreText.text = score.ToString();
                }
                if (lives > 0)
                {
                    lives--;
                }
                liveText.text = lives.ToString();

                if (lives == 0)
                {
                    // GAME OVER
                    rb.velocity = Vector3.zero;
                    FindObjectOfType<Game_Manager>().EndGame();
                }
            }
            else
            {
                if (lives > 0)
                { 
                    score++;
                }
                scoreText.text = score.ToString();
                collisionCounter++;
                Debug.Log("collision = "+collisionCounter.ToString());
                if(collisionCounter == maxCounter)
                {
                    //this.GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.GetColor("_Color");
                    skmrd.GetComponent<SkinnedMeshRenderer>().material.color = other.GetComponent<Renderer>().material.GetColor("_Color");
                    collisionCounter = 0;
                }

            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("E_Tree"))
        {
            lives = 0;  // GAME OVER
            liveText.text = lives.ToString();
            FindObjectOfType<Game_Manager>().EndGame();
        }

    }
    void Appear()
    {
        //this.GetComponent<Renderer>().enabled = true;
        skmrd.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }

}
