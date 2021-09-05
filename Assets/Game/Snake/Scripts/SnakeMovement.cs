using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> WalkingParticles;
    public bool canHaveInputs;
    [SerializeField] Transform fakeHead;
    [SerializeField] float snakeSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int maxRotation = 45;
    public Vector3 movementDir = Vector3.zero;
    public int rotationDir;
    public void Move()
    {
        if (!canHaveInputs)
        {
            rotationDir = 0;
            movementDir = Vector3.zero;
        }
        Quaternion target = Quaternion.Euler(0, rotationDir * maxRotation, 0);
        fakeHead.rotation = Quaternion.RotateTowards(fakeHead.rotation, target, rotationSpeed * Time.deltaTime);
        transform.Translate((transform.forward + movementDir) * snakeSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (GameManager.Instance.canInput)
        {
            if (!WalkingParticles[0].activeSelf)
            {

                WalkingParticles[0].SetActive(true);
                WalkingParticles[1].SetActive(true);

            }
            Move();
            snakeSpeed += 0.0001f;
        }
        else if (WalkingParticles[0].activeSelf)
        {
            WalkingParticles[0].SetActive(false);
            WalkingParticles[1].SetActive(false);

        }
    }
}
