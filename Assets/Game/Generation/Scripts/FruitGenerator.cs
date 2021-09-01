using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] Transform parent;
    public int XNumber;
    public int ZNumber;
    public float XOffset;
    public float ZOffset;

    public List<Vector3> RandomPositions = new List<Vector3>();
   
    public static FruitGenerator Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //GenerateFruits(ZstartPoint.position.z, ZendPoint.position.z, XstartPoint.position.x, XendPoint.position.x);
       
    }

    void Update()
    {
        
    }


    public void GenerateFruits(float ZstartPoint, float ZendPoint, float XstartPoint, float XendPoint, Transform parent)
    {
        RandomPositions.Clear();
        List<float> Xpositions = new List<float>();
        List<float> Zpositions = new List<float>();

        

        Xpositions = GenerateRandomPointsInDirection(XNumber,XstartPoint , XendPoint, Xpositions, XOffset);

        Zpositions = GenerateRandomPointsInDirection(ZNumber,ZstartPoint, ZendPoint, Zpositions, ZOffset);

        for (int i = 0; i < Xpositions.Count; i++)
        {
            for (int j = 0; j < Zpositions.Count; j++)
            {
                RandomPositions.Add(new Vector3(Xpositions[i], 0, Zpositions[j]));
            }
        }

        foreach (var pos in RandomPositions)
        {
            if (new bool[] { true, false }[Random.Range(0, 2)])  //<< genius 
                Instantiate(fruitPrefab, pos, fruitPrefab.transform.rotation, parent);
        }

    }

    private List<float> GenerateRandomPointsInDirection(int IterationNum,float DirectionStartPoint, float DirectionEndPoint, List<float> RandomPositions, float offset)
    {
        for (int i = 0; i < IterationNum; i++)
        {
            int randomPos = (int)Random.Range(DirectionStartPoint, DirectionEndPoint);

            if (!RandomPositions.Contains(randomPos) /*&& !RandomPositions.Contains(randomPos + offset) && !RandomPositions.Contains(randomPos-offset)*/)
                RandomPositions.Add(randomPos);
        }
        return RandomPositions;
    }
    
}
