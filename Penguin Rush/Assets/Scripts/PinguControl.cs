using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Touch mytouch = Input.GetTouch(0);
        Vector2 pos = mytouch.position;

	}
}
