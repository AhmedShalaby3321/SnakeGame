using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform fakeHead;
    [SerializeField] float snakeSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int maxRotation = 45;
    public void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Quaternion target = Quaternion.Euler(0, Input.GetAxis("Horizontal") * maxRotation, 0);
        fakeHead.rotation = Quaternion.RotateTowards(fakeHead.rotation, target, rotationSpeed * Time.deltaTime);
        transform.position += moveDir * snakeSpeed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
