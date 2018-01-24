using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coiny : MonoBehaviour {
    public static int CoinCount = 0;
    public static int CoinCountInitial = 0;

    public static int CoinWin = 10;
    public GameObject FirstLine1CurrentCoins;
    public GameObject FirstLine2TotalCoins;

    // Use this for initialization
    void Start () {

        Debug.Log("Coin created");
        ++Coiny.CoinCount;
        ++Coiny.CoinCountInitial;


        FirstLine1CurrentCoins = GameObject.Find("FirstLine1CurrentCoins");
        FirstLine2TotalCoins = GameObject.Find("FirstLine2TotalCoins");

        FirstLine2TotalCoins.GetComponent<Text>().text = Coiny.CoinCountInitial.ToString();

    }

    // Update is called once per frame
    void Update () {

    }
    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player")){
            Debug.Log("Le recogido");
            GetComponent<AudioSource>().Play();

            Destroy(gameObject);
        }

    }
    //called when destroy
    void OnDestroy()
    {
        //decrement coins
        --Coiny.CoinCount;

        Debug.Log("Quedan " + Coiny.CoinCount + " Monedas de " + Coiny.CoinCountInitial);

        FirstLine1CurrentCoins.GetComponent<Text>().text = (Coiny.CoinCountInitial - Coiny.CoinCount).ToString();

        //check remaining coins
        if (Coiny.CoinCount <= Coiny.CoinCountInitial - CoinWin)
        {
            //da win
            Debug.Log("Le win");

            GameObject Timer = GameObject.Find("Level Timer");
            Destroy(Timer);

            GameObject[] FireworkSystem =
                GameObject.FindGameObjectsWithTag("Fireworks");
            foreach(GameObject GO in FireworkSystem)
            {
                GO.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
