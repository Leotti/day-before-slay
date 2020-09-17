using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private GameObject player;
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("RightTarget");
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
