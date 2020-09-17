using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
   

    public GameObject door1;

    private float speed;
    
    
    private Vector2 targetPosition;

    public CharacterController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    public bool hasGreenKey;

    [HideInInspector]
    public bool hasBrownKey;

    [HideInInspector]
    public bool hasGreyKey;

    [HideInInspector]
    public bool hasCrow;


    void Start()
    {


        speed = runSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        


        if (Input.GetButtonDown("Jump"))
        {
            
            controller.SquashLock();
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Horizontal"))
        {

                anim.SetBool("isRunning", true);

            
        }
        else if (Input.GetButtonUp("Horizontal"))
        {

            anim.SetBool("isRunning", false);

        }

    }

    void FixedUpdate()
    {
        // Move our character
        

            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;

       



    }

    public void LandAnimation()
    {
        anim.SetTrigger("land");
    }

    public void CrouchAnimation()
    {
        anim.SetBool("isCrouching", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


    }

    public void KeyGreenBool()
    {
        hasGreenKey = true;
    }

    public void KeyBrownBool()
    {

    }

    public void KeyGreyBool()
    {

    }



}

