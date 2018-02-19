using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinRuning : MonoBehaviour {
    public float pinguPushSpeed;
    public Camera cam;
    public float speed; 
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.position += Vector3.forward * Time.deltaTime * speed;

        control();
    }
    void control()
    {
        //   Touch mytouch = Input.GetTouch(0);
        //   Vector2 pos = mytouch.position;
        bool mytouch = Input.GetMouseButton(0);
        Vector2 pos = Input.mousePosition;

        Vector3 pinguPosScreen = cam.WorldToScreenPoint(transform.position);
        

        //Debug.Log("x: " + pos.x);
        //Debug.Log("Position pingu: " + pinguPosScreen.x);

        if (mytouch == true)
        {

            PinguPush(pos.x, pinguPosScreen.x);
        }
        

    }

    private void PinguPush(float touch, float pingu)
    {
        if(touch > pingu)
        {
            GetComponent<Rigidbody>().AddForce(-1, 0, 0, ForceMode.Impulse);

        }
        else
        {
            GetComponent<Rigidbody>().AddForce(1, 0, 0, ForceMode.Impulse);

        }
    }
}

