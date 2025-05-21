using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; // tile means one level
    public Transform player;
    public float tileLength;
    public int tilesOnScreen = 5;
    public float spawnZ = 0f; // position to spawn the next tile


    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float safeZone = 70f; // distance before deleting the tile 

    void Start()
    {
        Debug.Log(player.position);

        SpawnTile();

        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 1)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }


    }

    void SpawnTile(int prefabIndex = -1)
    {

        GameObject go;
        if (prefabIndex == -1)
        {
            prefabIndex = RandomPrefabIndex();
        }
        go = Instantiate(tilePrefabs[prefabIndex],Vector3.forward*spawnZ,Quaternion.identity); // Quaternion.identity = no rotation

        activeTiles.Add(go);

        spawnZ += tileLength;


    }

    int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex;
        do
        {
            randomIndex = Random.Range(2, tilePrefabs.Length);
        }
        while (randomIndex == lastPrefabIndex);

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private void Update()
    {
        if (player.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile(); 
        }
    }

}
