using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour {
    public int tileHeight;
    public int tileWidth;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int GetTileHeight ()
    {
        return tileHeight;
    }
    public int GetTileWidth()
    {
        return tileWidth;
    }

}
