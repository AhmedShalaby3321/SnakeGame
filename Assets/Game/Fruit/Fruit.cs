using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fruit : MonoBehaviour
{
    [SerializeField] ColorsSO ColorsSO;
    public SnakeColors_Enum currfruitColor;
    Material myMaterial;
    void Start()
    {
        myMaterial = this.GetComponent<MeshRenderer>().material;
        int randomIndex = Random.Range(0, ColorsSO.colors.Count);
        myMaterial.color = ColorsSO.colors[randomIndex];
        currfruitColor = (SnakeColors_Enum)randomIndex;
    }
}
