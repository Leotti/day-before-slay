using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBooler : MonoBehaviour
{
    public GameObject player;
    public Transform rightPoint;
    public Transform leftPoint;
    private GameObject[] players;


    [HideInInspector]
    public bool spawnRight;
    public bool spawnLeft;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        UnityEngine.Debug.Log("Active? " + gameObject.activeInHierarchy);
        StartCoroutine(waitAndSpawn());
    }

    IEnumerator waitAndSpawn()
    {
        yield return 0;
        players = GameObject.FindGameObjectsWithTag("Player");
        if (spawnRight == true)
        {
            if(players.Length == 0)
            {
                yield return 0;
                Instantiate(player, rightPoint.position, rightPoint.rotation);
            }


        }
        else
        {
            if (players.Length == 0)
            {
                yield return 0;
                Instantiate(player, leftPoint.position, leftPoint.rotation);
            }
        
        }
    }

}
