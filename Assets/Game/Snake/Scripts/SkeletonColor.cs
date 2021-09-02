using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonColor : MonoBehaviour
{
    public enum skeletonType
    {
        Head,
        Body,
        Tail
    }
    //[SerializeField] SnakeManager snake;
    [SerializeField] MeshRenderer myMesh;
    [SerializeField] public skeletonType SkeletonType;

    private void Update()
    {
        ChangeColor(SnakeManager.Instance.colors.Colors_Dict[SnakeManager.Instance.currentSnakeColor][(int)SkeletonType]);
    }
    public void ChangeColor(Color color)
    {
        myMesh.material.color = color;
    }
}
