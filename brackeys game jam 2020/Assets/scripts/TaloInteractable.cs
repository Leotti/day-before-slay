using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TaloInteractable : MonoBehaviour
{
    
    private Animator anim;
    public Transform player;
    public float interactRadius;
    private keyHouse key;
    private GameObject keyObject;

    public UnityEvent interactEvent;

    public bool wantsGreen;
    public bool wantsBrown;
    public bool wantsGrey;
    public bool wantsCrowbar;

    public bool hasLock;

    void Start()
    {
        anim = GetComponent<Animator>();

        UnityEngine.Debug.Break();

        if(wantsGreen == true)
        {
            key = GameObject.FindGameObjectWithTag("GreenHouseKey").GetComponent<keyHouse>();
        }
        else if(wantsBrown == true)
        {
            key = GameObject.FindGameObjectWithTag("BrownHouseKey").GetComponent<keyHouse>();
        }
        else if(wantsGrey == true)
        {
            key = GameObject.FindGameObjectWithTag("GreyHouseKey").GetComponent<keyHouse>();
        }
        else if (wantsCrowbar == true)
        {
            key = GameObject.FindGameObjectWithTag("HouseCrowbar").GetComponent<keyHouse>();
        }



        if (wantsGreen == true)
        {
            keyObject = GameObject.FindGameObjectWithTag("GreenHouseKey");
        }
        else if (wantsBrown == true)
        {
            keyObject = GameObject.FindGameObjectWithTag("BrownHouseKey");
        }
        else if (wantsGrey == true)
        {
            keyObject = GameObject.FindGameObjectWithTag("GreyHouseKey");
        }
        else if (wantsCrowbar == true)
        {
            keyObject = GameObject.FindGameObjectWithTag("HouseCrowbar");
        }



    }


    void Update()
    {
        if (key != null)
        {
            if (Vector2.Distance(transform.position, key.transform.position) < 0.02 && hasLock == true)
            {
                if (keyObject != null)
                {
                    Destroy(keyObject);
                }

                Destroy(this.gameObject);
            }
        }

        
    }

    void OnMouseOver()
    {

        if (Vector2.Distance(transform.position, player.position) < interactRadius)
        {
            anim.SetBool("isHovering", true);
            UnityEngine.Debug.Log("hover");
        }



    }

    void OnMouseExit()
    {
        anim.SetBool("isHovering", false);
    }

    void OnMouseDown()
    {

    }

    void OnMouseUp()
    {



        if(hasLock == true)
        {
            if (Vector2.Distance(transform.position, player.position) < interactRadius && key.isFollowing == true)
            {
                key.GoToObject();
            }
        }
        else
        {
            interactEvent.Invoke();
        }

            
    }

    



}
