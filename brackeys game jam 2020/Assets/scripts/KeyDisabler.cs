using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDisabler : MonoBehaviour
{

    private GameObject player1;

    private GameObject greenKey;
    //private GameObject brownKey;
    private GameObject greyKey;

    public float disableRadius;

    void Start()
    {

        greenKey = GameObject.FindGameObjectWithTag("KeyGrey");
        greenKey = GameObject.FindGameObjectWithTag("keyGreen");
        player1 = GameObject.FindGameObjectWithTag("Player1");


    }


    void Update()
    {
        //greens

        if (player1 != null && Vector2.Distance(player1.transform.position, greenKey.transform.position) < disableRadius)
        {
            if (greenKey != null)
            {
                greenKey.SetActive(false);
            }
                
        }
        else
        {
            if(greenKey != null)
            {
                greenKey.SetActive(true);
            }
     
        }

        //greys

        //if (player1 != null && Vector2.Distance(player1.transform.position, greyKey.transform.position) < disableRadius && greyKey != null)
        //{
            //if (greyKey != null)
            //{
                //greyKey.SetActive(false);
            //}
                
        //}
        //else
        //{
            //if(greyKey != null)
            //{
                //greyKey.SetActive(true);
            //}
            
        //}

    }
}
