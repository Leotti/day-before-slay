using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class key : MonoBehaviour
{
    public float interactRadius;
    private GameObject player;
    private GameObject player1;
    private GameObject holdPlace;
    private PlayerMovement playerScript;
    public bool canSelect;
    public GameObject farTarget;
    public float speed;
    private bool goingToTargetPos;


    public bool isFollowing;

    private GameObject dropPlace;

    private Vector2 targetPosition;

    public UnityEvent interactEvent;


    public bool isFollowingFar;

    private Animator anim;


    public bool isGreen;
    public bool isBrown;
    public bool isGrey;



    void Start()
    {


        dropPlace = GameObject.FindGameObjectWithTag("DropPlace");
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        canSelect = true;
        player = GameObject.FindGameObjectWithTag("Player");
        player1 = GameObject.FindGameObjectWithTag("Player1");
        holdPlace = GameObject.FindGameObjectWithTag("KeyHold");
        anim = GetComponent<Animator>();
    }


    void Update()
    {



        if (targetPosition != null && Vector2.Distance(transform.position, targetPosition) > 0.01 && goingToTargetPos == true)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }


        if (isFollowingFar == true)
        {
            transform.position = new Vector3(farTarget.transform.position.x, farTarget.transform.position.y, transform.position.z);
        }



        if (Input.GetButtonDown("Crouch"))
        {
            if (playerScript.hasGreenKey == true && isFollowing == true)
            {
                Drop();
                playerScript.hasGreenKey = false;
            }
        }



        if (isFollowing == true)
        {
            isFollowingFar = false;
            transform.position = new Vector3(holdPlace.transform.position.x, holdPlace.transform.position.y, transform.position.z);
        }
    }



    void OnMouseOver()
    {


        if (Vector2.Distance(transform.position, player.transform.position) < interactRadius)
        {
            if (canSelect == true)
            {
                if (isFollowing == false)
                {
                    anim.SetBool("isHovering", true);
                }
                
            }
            else
            {
                anim.SetBool("isHovering", false);
            }
            
        }



    }

    void OnMouseDown()
    {

        playerScript.KeyGreenBool();
        if (Vector2.Distance(transform.position, player.transform.position) < interactRadius)
        {
            isFollowing = true;
        }
            
    }

    void OnMouseExit()
    {
        anim.SetBool("isHovering", false);
    }

    void OnMouseUp()
    {
        
    }

    public void Drop()
    {
        if(isGreen == true)
        {
            playerScript.hasGreenKey = false;
        }

        if (isBrown == true)
        {
            playerScript.hasBrownKey = false;
        }

        if (isGrey == true)
        {
            playerScript.hasGreyKey = false;
        }

        isFollowing = false;
        targetPosition = dropPlace.transform.position;
        goingToTargetPos = true;
    }

    public void OnMouseDownTwo()
    {
        playerScript.KeyGreenBool();

        isFollowing = true;
     
    }


}
