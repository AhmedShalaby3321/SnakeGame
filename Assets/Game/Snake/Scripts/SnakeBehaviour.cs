using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SnakeBehaviour : MonoBehaviour
{
    //[SerializeField] SkinnedMeshRenderer skmrd;
    //[SerializeField] SnakeManager snake;

    const int maxLives = 5;
    public static int lives;
    public static int score;
    int collisionCounter;
    int maxCounter = 5;

    //public Game_Manager game_Manager;

    void Start()
    {
        lives = maxLives;
        score = 0;
        collisionCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit"))
        {
            Fruit fruit = other.GetComponent<Fruit>();
            if(SnakeManager.Instance.currentSnakeColor == fruit.currfruitColor)
            {
                Debug.Log("same color");
                SnakeManager.Instance.AddBodyPart();
            }
            else
            {
                Debug.Log("different");
                SnakeManager.Instance.RemoveBodyPart();
            }
        }
      

        //if (other.CompareTag("E_Bomb"))
        //{
        //    other.GetComponent<Renderer>().enabled = false;
        //    skmrd.GetComponent<SkinnedMeshRenderer>().enabled = false;
        //    Invoke("Appear", 2f);
        //}

        //if (other.CompareTag("Balls"))
        //{
        //    other.GetComponent<Renderer>().enabled = false;
        //    if (skmrd.GetComponent<SkinnedMeshRenderer>().material.color == other.GetComponent<Renderer>().material.GetColor("_Color"))
        //    {
        //        if (score > 0)
        //        {
        //            score--;
        //        }
        //        if (lives > 0)
        //        {
        //            lives--;
        //        }

        //        if (lives == 0)
        //        {
        //            // GAME OVER
        //            game_Manager.EndGame();
        //        }
        //    }
        //    else
        //    {
        //        if (lives > 0)
        //        {
        //            score++;
        //        }
        //        collisionCounter++;
        //        Debug.Log("collision = " + collisionCounter.ToString());
        //        if (collisionCounter == maxCounter)
        //        {
        //            skmrd.GetComponent<SkinnedMeshRenderer>().material.color = other.GetComponent<Renderer>().material.GetColor("_Color");
        //            collisionCounter = 0;
        //        }

        //    }
        //}

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("E_Tree"))
    //    {
    //        lives = 0;  // GAME OVER
    //        game_Manager.EndGame();
    //    }

    //}
    void Appear()
    {
        //skmrd.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }

}
