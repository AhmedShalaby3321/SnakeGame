using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] Transform parent;
    public int XNumber;
    public int ZNumber;
    public List<Vector3> RandomPositions = new List<Vector3>();



    [SerializeField] Transform ZstartPoint;
    [SerializeField] Transform ZendPoint;

    [SerializeField] Transform XstartPoint;
    [SerializeField] Transform XendPoint;

    bool firstTime = true;
    void Start()
    {
        GenerateFruits(ZstartPoint.position.z, ZendPoint.position.z, XstartPoint.position.x, XendPoint.position.x);
        foreach (var pos in RandomPositions)
        {
            if (new bool[] { true, false }[Random.Range(0, 2)])  //<< genius 
                Instantiate(fruitPrefab, pos , fruitPrefab.transform.rotation, this.transform);
        }
    }

    void Update()
    {
        
    }


    public void GenerateFruits(float ZstartPoint, float ZendPoint, float XstartPoint, float XendPoint)
    {
        List<float> Xpositions = new List<float>();
        List<float> Zpositions = new List<float>();

        

        Xpositions = GenerateRandomPointsInDirection(XNumber,XstartPoint , XendPoint, Xpositions);

        Zpositions = GenerateRandomPointsInDirection(ZNumber,ZstartPoint, ZendPoint, Zpositions);

        for (int i = 0; i < Xpositions.Count; i++)
        {
            for (int j = 0; j < Zpositions.Count; j++)
            {
                RandomPositions.Add(new Vector3(Xpositions[i], 0, Zpositions[j]));
            }
        }


    }

    private List<float> GenerateRandomPointsInDirection(int IterationNum,float DirectionStartPoint, float DirectionEndPoint, List<float> RandomPositions)
    {
        for (int i = 0; i < IterationNum; i++)
        {
            int randomPos = (int)Random.Range(DirectionStartPoint, DirectionEndPoint);

            if (!RandomPositions.Contains(randomPos))
                RandomPositions.Add(randomPos);
        }
        return RandomPositions;
    }
    
}
