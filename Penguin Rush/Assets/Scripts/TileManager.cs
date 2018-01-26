using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -10.0f; //where in Z are we spawning tiles
    public float tileLenght = 4.0f;
    public int tilemax = 14; //max tiles on screen
    private List<GameObject> activeTiles; //list to save tiles and track them to destroy the last
    public float safeZone = 15.0f; //zone that need to be surpassed to destroy the last 
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        for (int i = 0; i < tilemax; i++)
        {
            SpawnTile();
        }


    }

    // Update is called once per frame
    void Update () {
		if(playerTransform.position.z - safeZone > (spawnZ - tilemax * tileLenght))
            {

                SpawnTile();
                DeleteTile();
            }
	}

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLenght;
        activeTiles.Add(go);

    }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
