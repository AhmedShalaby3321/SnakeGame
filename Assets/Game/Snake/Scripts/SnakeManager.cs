using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
public enum SnakeColors_Enum
{
    Cyan,
    Green,
    Purple,
    Yellow
}
public class SnakeManager : MonoBehaviour
{
    [SerializeField] MMFeedbacks EatingVFX;
    [SerializeField] public SnakeColorsSO colors;
    [SerializeField] Skeleton bodyPrefab;
    [SerializeField] Skeleton DefaultBody;
    [SerializeField] List<Skeleton> bodyParts = new List<Skeleton>();
    [SerializeField] Transform tail;
    [SerializeField] float tailOffset;
    [SerializeField] int maxSnakeLength = 10;
    [SerializeField] int minSnakeLength = 2;
    [SerializeField] DynamicBone dynamicBone;
    [SerializeField] SkeletonColor HeadMesh;
    [SerializeField] SkeletonColor TailMesh;

    private int snakeLength = 1;

    /*[HideInInspector] */public SnakeColors_Enum currentSnakeColor;

    public static SnakeManager Instance;
    private void Awake()
    {
        Instance = this;
        InitColorsDictionary();
    }

    private void Start()
    {
        bodyParts.Add(DefaultBody);
    }

    //private void Update()
    //{
    //    //ChangeColor();
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        AddBodyPart();
    //    }
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        RemoveBodyPart();
    //    }
    //}
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
        if (bodyParts.Count-1 > minSnakeLength)
        {
            Destroy(bodyParts[bodyParts.Count - 1].gameObject);
            bodyParts.RemoveAt(bodyParts.Count - 1);
            SetTailPos();
            dynamicBone.ResetAll();
            snakeLength--;
        }
        else
        {
            GameManager.Instance.Lose();
        }
    }

    public void AddBodyPart()
    {
        EatingVFX.PlayFeedbacks();
        snakeLength++;
        if (bodyParts.Count < maxSnakeLength)
        {
            Skeleton addedBodyPart = (Skeleton)Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].endPoint.position, Quaternion.identity, bodyParts[bodyParts.Count - 1].endPoint);
            bodyParts.Add(addedBodyPart);
            SetTailPos();
            dynamicBone.ResetAll();
        }
    }

    public void ChangeColor(SnakeColors_Enum newColor)
    {
        currentSnakeColor = newColor;
        HeadMesh.ChangeColor(colors.Colors_Dict[currentSnakeColor][0]);
        foreach (var body in bodyParts)
        {
            SkeletonColor InstantiatedBody = body.GetComponent<SkeletonColor>();
            if (InstantiatedBody != null && InstantiatedBody.SkeletonType == SkeletonColor.skeletonType.Body)
            {
                InstantiatedBody.ChangeColor(colors.Colors_Dict[currentSnakeColor][1]); 
            }
        }
        TailMesh.ChangeColor(colors.Colors_Dict[currentSnakeColor][2]);
    }


    private void InitColorsDictionary()
    {
        if (!colors.Colors_Dict.ContainsKey(SnakeColors_Enum.Cyan))
            colors.Colors_Dict.Add(SnakeColors_Enum.Cyan, colors.Cyan);

        if (!colors.Colors_Dict.ContainsKey(SnakeColors_Enum.Green))
            colors.Colors_Dict.Add(SnakeColors_Enum.Green, colors.Green);

        if (!colors.Colors_Dict.ContainsKey(SnakeColors_Enum.Purple))
            colors.Colors_Dict.Add(SnakeColors_Enum.Purple, colors.Purple);

        if (!colors.Colors_Dict.ContainsKey(SnakeColors_Enum.Yellow))
            colors.Colors_Dict.Add(SnakeColors_Enum.Yellow, colors.Yellow);
    }
}
