using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tile : MonoBehaviour
{
    [SerializeField] public Transform ZstartPoint;
    [SerializeField] public Transform ZendPoint;
    [SerializeField] public Transform XstartPoint;
    [SerializeField] public Transform XendPoint;
    public Transform fruitParent;
    [SerializeField] MeshRenderer mesh;
    [HideInInspector] public float length;

    private void Awake()
    {
        length = mesh.bounds.size.z * 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TilesGenerator.Instance.InstantiateTile();
        }
    }
}
