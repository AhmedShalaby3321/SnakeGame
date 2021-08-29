using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public Vector3 oldPos;
    public Vector3 newPos;
    private void Start()
    {
        oldPos = this.transform.position;
        newPos = oldPos;
    }

}
