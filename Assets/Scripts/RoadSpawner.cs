using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] roadPrefab;
    public float ySpawn = 0f;
    public Transform playerTransform;
    
    private float roadLength = 24.6f;
    private int maxRoads = 3;
    private List<GameObject> activeRoads = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < maxRoads; i++)
        {
            if(i == 0)
            {
                SpawnRoad(0);
            }
            else
            {   
                SpawnRoad(Random.Range(1, roadPrefab.Length));
            }
        }
    }

    void Update()
    {
        if(playerTransform.position.y - 20 > ySpawn - (maxRoads*roadLength))
        {
            SpawnRoad(Random.Range(1, roadPrefab.Length));
            DeleteRoads();
        }
    }

    public void SpawnRoad(int Index)
    {
        GameObject go = Instantiate(roadPrefab[Index], transform.up * ySpawn, transform.rotation);
        activeRoads.Add(go);
        ySpawn += roadLength;
    }

    private void DeleteRoads()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}