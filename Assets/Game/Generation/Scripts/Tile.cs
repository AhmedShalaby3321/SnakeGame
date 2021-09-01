using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tile : MonoBehaviour
{
    [SerializeField] Transform ZstartPoint;
    [SerializeField] Transform ZendPoint;

    [SerializeField] Transform XstartPoint;
    [SerializeField] Transform XendPoint;

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
