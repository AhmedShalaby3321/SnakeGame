using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tile : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] MeshRenderer mesh;
    [HideInInspector] public float length;

    private void Awake()
    {
        length = mesh.bounds.size.z * 3;
        Debug.Log(length.ToString());
        // Mathf.Abs((startPoint.position - endPoint.position).magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TilesGenerator.Instance.InstantiateTile();
        }
    }
}
