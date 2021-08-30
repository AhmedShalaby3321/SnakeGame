using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    [SerializeField] List<Tile> TilesPrefabs;
    [SerializeField] public Tile prevTile;
    [SerializeField] int maxNumberOfTileInTheScene;
    [HideInInspector] public Tile currentTile;
    [HideInInspector] public List<Tile> TilesInThescene;
    List<int> takenIndeces;


    public static TilesGenerator Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        takenIndeces = new List<int>();
        TilesInThescene = new List<Tile>();
        TilesInThescene.Add(prevTile);
    }
    public void InstantiateTile()
    {

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, TilesPrefabs.Count);
        } while (takenIndeces.Contains(randomIndex));
        takenIndeces.Add(randomIndex);

        Tile RndTileToInstantiate = TilesPrefabs[randomIndex];

        float displacment = prevTile.length /2 + RndTileToInstantiate.length/2 ;

        currentTile = Instantiate(RndTileToInstantiate, prevTile.transform.localPosition + (Vector3.forward * displacment*2), RndTileToInstantiate.transform.rotation, this.transform);

        if (TilesInThescene.Count >= maxNumberOfTileInTheScene)
        {
            Destroy(TilesInThescene[0].gameObject, 0.5f);
            TilesInThescene.RemoveAt(0);
            
        }
        TilesInThescene.Add(currentTile);

        if (takenIndeces.Count == TilesPrefabs.Count)
        {
            takenIndeces.Clear();
        }

        prevTile = currentTile;
    }

}
