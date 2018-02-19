using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -40.0f; //where in Z are we spawning tiles
    private float spawnY = 0.0f; //where in Z are we spawning tiles

    public float tileLenght = 12.0f;
    public float tileHeight = 12.0f;

    public int tilemax = 14; //max tiles on screen
    private List<GameObject> activeTiles; //list to save tiles and track them to destroy the last
    public float safeZone = 60; //zone that need to be surpassed to destroy the last 
    private int rep = -1, last = -1; //to check if im repeating too much

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        SpawnTile(0);

        for (int i = 0; i < tilemax; i++)
        {
            SpawnTile();

        }


    }

    // Update is called once per frame
    void Update () {
		if(playerTransform.position.z - safeZone > (spawnZ - tilemax * tileLenght ))
            {

            SpawnTile();
            DeleteTile();
            }
	}
    
    void SpawnTile(int prefabIndex = -1)
    {
        //Debug.Log("Spawn Z : " + spawnZ + " Spawn Y: " + spawnY + " PlayerZ: " + playerTransform.position.z);
        GameObject go;
        if (prefabIndex == -1)
        {
            System.Random rnd = new System.Random();
            prefabIndex = rnd.Next(0, tilePrefabs.Length);
            Debug.Log(prefabIndex);
            Debug.Log(last + " "  + rep);

            if (last == prefabIndex)
            {

                rep++;
                if (rep > 4) //checking if i repeat 4 times to change the tile
                {
                    Debug.Log("repe");
                    rnd = new System.Random();
                    prefabIndex = rnd.Next(0, tilePrefabs.Length);
                    rep = -1;
                }
            }
            else rep = 0;
            last = prefabIndex;
        }
        go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);

        tileLenght = go.GetComponent<TileData>().GetTileWidth();
        tileHeight = go.GetComponent<TileData>().GetTileHeight();

        go.transform.position = Vector3.forward * (tileLenght +spawnZ) + Vector3.down * (tileHeight + spawnY);

        spawnY += tileHeight;
        spawnZ += tileLenght;
        activeTiles.Add(go);
    }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
