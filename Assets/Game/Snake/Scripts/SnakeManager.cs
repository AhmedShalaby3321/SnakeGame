using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SnakeColors_Enum
{
    Cyan,
    Green,
    Purple,
    Yellow
}
public class SnakeManager : MonoBehaviour
{
    [SerializeField] public SnakeColorsSO colors;
    [SerializeField] Skeleton bodyPrefab;
    [SerializeField] List<Skeleton> bodyParts = new List<Skeleton>();
    [SerializeField] Transform tail;
    [SerializeField] float tailOffset;
    [SerializeField] int maxSnakeLength = 10;
    [SerializeField] int minSnakeLength = 2;
    [SerializeField] DynamicBone dynamicBone;
    [SerializeField] SkeletonColor HeadMesh;
    [SerializeField] SkeletonColor TailMesh;
    [SerializeField] SkeletonColor BodyMesh;

    private int snakeLength = 1;

    /*[HideInInspector] */public SnakeColors_Enum currentSnakeColor;

    public static SnakeManager Instance;
    private void Awake()
    {
        Instance = this;

        colors.Colors_Dict.Add(SnakeColors_Enum.Cyan, colors.Cyan);
        colors.Colors_Dict.Add(SnakeColors_Enum.Green,colors.Green);
        colors.Colors_Dict.Add(SnakeColors_Enum.Purple,colors.Purple);
        colors.Colors_Dict.Add(SnakeColors_Enum.Yellow,colors.Yellow);
    }
    private void Update()
    {
        //ChangeColor();
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
        if (bodyParts.Count > minSnakeLength)
        {
            Destroy(bodyParts[bodyParts.Count - 1].gameObject);
            bodyParts.RemoveAt(bodyParts.Count - 1);
            SetTailPos();
            dynamicBone.ResetAll();
            snakeLength--;
        }
    }

    public void AddBodyPart()
    {
        snakeLength++;
        if (bodyParts.Count < maxSnakeLength)
        {
            Skeleton addedBodyPart = (Skeleton)Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].endPoint.position, Quaternion.identity, bodyParts[bodyParts.Count - 1].endPoint);
            bodyParts.Add(addedBodyPart);
            SetTailPos();
            dynamicBone.ResetAll();
        }
    }

    public void ChangeColor()
    {
        HeadMesh.ChangeColor(colors.Colors_Dict[currentSnakeColor][0]);
        foreach (var body in bodyParts)
        {
            SkeletonColor InstantiatedBody = body.GetComponent<SkeletonColor>();
            InstantiatedBody.ChangeColor(colors.Colors_Dict[currentSnakeColor][1]);
        }
        TailMesh.ChangeColor(colors.Colors_Dict[currentSnakeColor][2]);
    }
}
