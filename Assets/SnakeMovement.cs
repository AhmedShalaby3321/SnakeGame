using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float snakeSpeed;
    public void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += moveDir * snakeSpeed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
