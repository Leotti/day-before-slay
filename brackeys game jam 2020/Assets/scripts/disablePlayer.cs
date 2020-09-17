using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablePlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
