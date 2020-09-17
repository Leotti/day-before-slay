using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Events;
using UnityEngine;
using System.Collections.Specialized;

public class Interactable : MonoBehaviour
{

    private Animator anim;
    private GameObject player;
    public float interactRadius;
    
  

    //eventit
    public UnityEvent interactEvent;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

    }

    void OnMouseOver()
    {

        if (Vector2.Distance(transform.position, player.transform.position) < interactRadius)
        {
            anim.SetBool("isHovering", true);
        }


        
    }

    void OnMouseExit()
    {
        anim.SetBool("isHovering", false);
    }

    void OnMouseUp()
    {

        interactEvent.Invoke();
    }



}
