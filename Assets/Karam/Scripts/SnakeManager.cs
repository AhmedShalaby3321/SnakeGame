using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] Skeleton bodyPrefab;
    [SerializeField] List<Skeleton> bodyParts = new List<Skeleton>();
    [SerializeField] Transform tail;
    [SerializeField] float tailOffset;
    [SerializeField] int maxSnakeLength = 10;
    [SerializeField] int minSnakeLength = 2;
    [SerializeField] float snakeActualLength;
    [SerializeField] int numberOfIteration = 50;
    private void Start()
    {
        snakeActualLength = Vector3.Distance(bodyParts[0].endPoint.position, bodyParts[bodyParts.Count - 1].endPoint.position);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddBodyPart();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            RemoveBodyPart();
        }

    }
    public void SetTailPos()
    {
        if (bodyParts != null)
        {
            tail.parent = null;
            tail.SetParent(bodyParts[bodyParts.Count - 1].endPoint);
            tail.transform.localPosition = new Vector3(0, 0, tailOffset);
        }
    }
    public void RemoveBodyPart()
    {
        Debug.Log(bodyParts.Count);
        if (bodyParts.Count > minSnakeLength)
        {
            Destroy(bodyParts[bodyParts.Count - 1].gameObject);
            bodyParts.RemoveAt(bodyParts.Count - 1);
            snakeActualLength = Vector3.Distance(bodyParts[0].endPoint.position, bodyParts[bodyParts.Count - 1].endPoint.position);
            SetTailPos();
        }

    }
    public void AnimateBody()
    {
        int index = bodyParts.Count - 1;
        while (index >= 0)
        {

        }
    }
    public void AddBodyPart()
    {
        if (bodyParts.Count < maxSnakeLength)
        {
            Skeleton addedBodyPart = (Skeleton)Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].endPoint.position, Quaternion.identity, bodyParts[bodyParts.Count - 1].endPoint);
            bodyParts.Add(addedBodyPart);

            snakeActualLength = Vector3.Distance(bodyParts[0].endPoint.position, bodyParts[bodyParts.Count - 1].endPoint.position);
            SetTailPos();
        }
    }
}
