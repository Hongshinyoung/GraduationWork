using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUi : MonoBehaviour
{
    public GameObject Marketdisp;
    bool activeMarket = false;
    bool coli = false;

    private void Start()
    {
        Marketdisp.SetActive(activeMarket);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("상점이용가능지역");
            coli = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("상점이용불가지역");
            coli = false;
        }
    }


    private void Update()
    {
        if(coli == true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                activeMarket = !activeMarket;
                Marketdisp.SetActive(activeMarket);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                activeMarket = false;
                Marketdisp.SetActive(activeMarket);
            }
        }
    }
}
