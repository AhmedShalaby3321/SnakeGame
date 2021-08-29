using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Snake : MonoBehaviour
{
    public static float ForwardSpeed = 7f;
    public static float SidesSpeed = 5f;

    public Game_Manager game_Manager;
    public Rigidbody rb;

    //public void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}
    public void Update()
    {
        bool a = Input.GetKey("a");   // left
        bool d = Input.GetKey("d");   // right
        transform.Translate(0, 0, ForwardSpeed * Time.deltaTime);
        if (a)
        {
            transform.Translate(-SidesSpeed * Time.deltaTime, 0, 0);
        }
        if (d)
        {
            transform.Translate(SidesSpeed * Time.deltaTime, 0, 0);
        }

        if (rb.position.y < -1f)
        {
            game_Manager.EndGame();
        }
    }

    ////////////////////////////
    //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //this.GetComponent<Rigidbody>().MovePosition(transform.position + m_Input.normalized * Time.deltaTime * 5);
//}
    ////////////////////////////

}
