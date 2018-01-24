using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    //max time to complete level (seconds)
    public float MaxTime = 60f;
    public float StartTime = 0f;
    public float CurrentTime = 0f;

    public GameObject TextTime;
    int min;
    int s;
    //countdown
    [SerializeField]
    private float Countdown = 0;
	// Use this for initialization
	void Start () {
        Countdown = MaxTime;
        TextTime = GameObject.Find("SecondLineTime");

    }

    // Update is called once per frame
    void Update () {
        //reduce time
        Countdown -= Time.deltaTime;
        CurrentTime += Time.deltaTime;

        min = (int)CurrentTime / 60;
        s = (int) CurrentTime - (min * 60);

        TextTime.GetComponent<Text>().text = min.ToString("D2") + " : " + s.ToString("D2");
        //restart level if time runs out
        /*        if(Countdown <= 0)
              {
                    //ForcedReset coin count
                    Coiny.CoinCount = 0;
                    Application.LoadLevel(Application.loadedLevel); //Habra que cambiarlo

                }
        */
    }
}
