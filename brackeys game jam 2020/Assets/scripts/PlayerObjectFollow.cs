using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectFollow : MonoBehaviour
{

    public GameObject player;


    void Start()
    {

    }

    void FixedUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        
    }

}
