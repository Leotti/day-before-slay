using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBox : MonoBehaviour
{
    private keyHouse greyHouseKey;


    void Awake()
    {
        greyHouseKey = GameObject.FindGameObjectWithTag("GreyHouseKey").GetComponent<keyHouse>();

        if(greyHouseKey != null)
        {
            greyHouseKey.enabled = false;
        }
        
    }

    void Start()
    {
        greyHouseKey = GameObject.FindGameObjectWithTag("GreyHouseKey").GetComponent<keyHouse>();
    }


    void Update()
    {
        
    }

    public void SelfDestruct()
    {
  
        greyHouseKey.enabled = true;

        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        UnityEngine.Debug.Log("self destrukt");
        SelfDestruct();
    }
}
