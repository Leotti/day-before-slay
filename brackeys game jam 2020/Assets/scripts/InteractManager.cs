using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public InterTarget interTarget;

    private GameObject windowOpen;
    public GameObject crossPaper;
    public Transform crossSpawn;


    private GameObject[] windowsOpen;



    //interact windowit
    public GameObject ekaTaloDeskLuuku;
    public GameObject familiFoto;
    public GameObject partiLappu;

    void Start()
    {

    }


    void Update()
    {
        windowOpen = GameObject.FindGameObjectWithTag("InteractWindow");
        windowsOpen = GameObject.FindGameObjectsWithTag("InteractWindow");
    }


    //window funktionit

    public void EkaTaloLuukku()
    {
        
        if (windowsOpen.Length == 0)
        {
            Instantiate(ekaTaloDeskLuuku, transform.position, transform.rotation);
        }
            
        
    }

    public void PartiLappu()
    {
        if (windowsOpen.Length == 0)
        {
            Instantiate(partiLappu, transform.position, transform.rotation);
        }
        
    }

    public void FamiliFoto()
    {
        
    }


    public void CrossPaper()
    {
        Instantiate(crossPaper, crossSpawn.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InteractWindow")
        {
            Destroy(windowOpen);
        }
    }

}
