using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{ 
    public Text coinText;
    public bool canAddCoin;
    public int maxCoin;
    void Update()
    {
        if (maxCoin >= 90)
        {
            canAddCoin = false;
        }
        else
        {
            canAddCoin = true;
        }

        coinText.text = "" + maxCoin;


    }
    public void AddCoin()
    {

        if (maxCoin >= 100)
        {
            maxCoin = 100;
        }
        else
        {
            maxCoin += 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(GameObject.FindWithTag("Coin"));

            if (canAddCoin)
            {
                AddCoin();
            }

        }
    }
}
