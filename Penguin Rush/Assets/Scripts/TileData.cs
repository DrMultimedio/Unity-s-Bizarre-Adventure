using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour {
    public float tileHeight;
    public float tileWidth;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public float GetTileHeight ()
    {
        return tileHeight;
    }
    public float GetTileWidth()
    {
        return tileWidth;
    }

}
