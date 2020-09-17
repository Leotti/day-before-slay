using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class keyHouse : MonoBehaviour
{
    public float interactRadius;
    private GameObject player;
    private GameObject farTarget;
    public float speed;

    private PlayerMovement streetPlayerScript;
    private PlayerMovement player1Script;

    public bool goingToTargetPos;
    public bool isFollowing;
    private GameObject holdPlace;

    public bool canSelect;
    private bool isFollowingFar;

    private GameObject dontDestroy;

    public GameObject objectToGoTo;
    private Vector2 targetPosition;
    private GameObject dropPlace;
    private GameObject farPlaceTarget;

    private key streetCrowbar;
    private key streetGreenKey;
    private key streetBrownKey;
    private key streetGreyKey;

    private Animator anim;

    public UnityEvent interactEvent;
    public UnityEvent onDropEvent;

    [HideInInspector]
    public bool goToFar;

    public bool isGreen;
    public bool isBrown;
    public bool isGrey;
    public bool isCrow;

    private SceneChecker sceneCheckerScript;


    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);


    }

    void Start()
    {
        if(isGreen == true)
        {
            objectToGoTo = GameObject.Find("lukkoluukku");
        }
        else if(isGrey == true)
        {
            objectToGoTo = GameObject.Find("lukittu pieni luukku");
        }
        //else if(isBrown == true)
        //{

        //}
        //else if(isCrow == true)
        //{

        //}


        sceneCheckerScript = GameObject.FindGameObjectWithTag("SceneChecker").GetComponent<SceneChecker>();

        farPlaceTarget = GameObject.FindGameObjectWithTag("StreetHouseKeyTarget");

        canSelect = true;
        dontDestroy = GameObject.FindGameObjectWithTag("DontDestroy");

        streetGreenKey = GameObject.FindGameObjectWithTag("keyGreen").GetComponent<key>();
        //streetBrownKey = GameObject.FindGameObjectWithTag("KeyBrown").GetComponent<key>(); 
        streetGreyKey = GameObject.FindGameObjectWithTag("KeyGrey").GetComponent<key>(); 
        //streetCrowbar = GameObject.FindGameObjectWithTag("CrowBar").GetComponent<key>();

        dropPlace = GameObject.FindGameObjectWithTag("DropPlace1");
        farTarget = GameObject.FindGameObjectWithTag("FarTarget1");
        player = GameObject.FindGameObjectWithTag("Player1");
        player1Script = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        streetPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();



        if (streetPlayerScript.hasBrownKey == true && isBrown == true)
        {
            player1Script.hasBrownKey = true;
            isFollowing = true;

            streetGreenKey.isFollowingFar = true;

            if(streetGreyKey != null)
            {
                streetGreyKey.isFollowingFar = true;
            }
            
        }

        else
        {
            if (streetPlayerScript.hasGreyKey == true && isGrey == true)
            {
                player1Script.hasGreyKey = true;
                isFollowing = true;

                streetGreenKey.isFollowingFar = true;
                streetBrownKey.isFollowingFar = true;
                //streetCrowbar.isFollowingFar = true;
            }
            else
            {
                if (streetPlayerScript.hasGreenKey == true && isGreen == true)
                {
                    UnityEngine.Debug.Log("snosh");
                    player1Script.hasGreenKey = true;
                    isFollowing = true;

                    //if(streetBrownKey != null)
                    //{
                        //streetBrownKey.isFollowingFar = true;
                    //}

                    if (streetGreyKey != null)
                    {
                        streetGreyKey.isFollowingFar = true;
                    }
                }
                //else if(streetPlayerScript.hasBrownKey == true && isBrown == true)
                //{
                    //player1Script.hasBrownKey = true;
                    //isFollowing = true;

                    //streetGreenKey.isFollowingFar = true;
                    //streetGreyKey.isFollowingFar = true;
                    //streetCrowbar.isFollowingFar = true;
                //}
            }
        }






    }


    void Update()
    {

        if (goToFar == true)
        {
            transform.position = farPlaceTarget.transform.position;
        }

        player = GameObject.FindGameObjectWithTag("Player1");
        player1Script = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        streetPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        if (player1Script != null)
        {
            holdPlace = GameObject.FindGameObjectWithTag("KeyHold1");
        }

        if (targetPosition != null && Vector2.Distance(transform.position, targetPosition) > 0.01 && goingToTargetPos == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (targetPosition != null && Vector2.Distance(transform.position, targetPosition) < 0.01)
        {
            goingToTargetPos = false;
        }


        if (isFollowingFar == true && farTarget != null)
        {
            transform.position = new Vector3(farTarget.transform.position.x, farTarget.transform.position.y, transform.position.z);
        }



        if (Input.GetButtonDown("Crouch"))
        {
            if (player1Script.hasGreenKey == true && isFollowing == true && isGreen == true)
            {
                Drop();

                if(isGreen == true)
                {
                    sceneCheckerScript.greenIsDropped = true;
                }

                if(isGrey == true)
                {
                    sceneCheckerScript.greyIsDropped = true;
                }

                //if(isBrown == true)
                //{
                //sceneCheckerScript.brownIsDropped = true;
                //}

                //if (isCrow == true)
                //{
                    //sceneCheckerScript.crowIsDropped = true;
                //}


                player1Script.hasGreenKey = false;
                streetPlayerScript.hasGreenKey = false;
                streetGreenKey.isFollowingFar = true;
                onDropEvent.Invoke();
            }
        }



        if (isFollowing == true)
        {
            if(isGreen == true)
            {
                sceneCheckerScript.greenIsDropped = false;
            }

            if (isGrey == true)
            {
                sceneCheckerScript.greyIsDropped = false;
            }

            //if(isBrown == true)
            //{
            //sceneCheckerScript.brownIsDropped = false;
            //}

            //if (isCrow == true)
            //{
            //sceneCheckerScript.crowIsDropped = false;
            //}


            transform.position = new Vector3(holdPlace.transform.position.x, holdPlace.transform.position.y, transform.position.z);


        }




    }


    void OnMouseOver()
    {
        UnityEngine.Debug.Log("hoverr");

        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.transform.position) < interactRadius)
            {
                if (canSelect == true)
                {
                    if (isFollowing == false && goingToTargetPos == false)
                    {
                        anim.SetBool("isHovering", true);
                        UnityEngine.Debug.Log("hoverr");
                    }

                }
                else
                {

                    anim.SetBool("isHovering", false);
                }
            }


        }



    }

    void OnMouseDown()
    {
        if (player != null)
        {
            if (player1Script.hasGreenKey == false && player1Script.hasBrownKey == false && player1Script.hasGreyKey == false)
            {
                if (Vector2.Distance(transform.position, player.transform.position) < interactRadius)
                {
                    if (isGreen == true)
                    {
                        streetGreenKey.OnMouseDownTwo();
                        player1Script.hasGreenKey = true;
                        isFollowing = true;
                    }
                    else if (isBrown == true)
                    {
                        player1Script.hasBrownKey = true;
                        isFollowing = true;
                    }
                    else if (isGrey == true)
                    {
                        
                        player1Script.hasGreyKey = true;
                        isFollowing = true;
                    }


                }
            }

        }

    }

    void OnMouseExit()
    {
        anim.SetBool("isHovering", false);
    }

    void OnMouseUp()
    {

    }


    public void GoToObject()
    {
        if (player1Script.hasGreenKey == true || player1Script.hasBrownKey == true || player1Script.hasGreyKey == true)
        {
            isFollowing = false;
            targetPosition = objectToGoTo.transform.position;
            goingToTargetPos = true;
        }

    }


    public void Drop()
    {
        isFollowing = false;
        targetPosition = dropPlace.transform.position;
        goingToTargetPos = true;
    }

    //street key script disabling

    public void DropGreenStreetKey()
    {
        streetGreenKey.isFollowingFar = true;
    }

    public void DropBrownStreetKey()
    {
        streetBrownKey.isFollowingFar = true;
    }

    public void DropGreyStreetKey()
    {
        streetGreyKey.isFollowingFar = true;
    }

    private void FindPlayer()
    {

    }






}
