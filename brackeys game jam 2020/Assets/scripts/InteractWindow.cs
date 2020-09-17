using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWindow : MonoBehaviour
{

    private Vector2 targetPosition;
    private InterTarget target;
    private InteractManager manager;
    private Animator anim;
    private bool goingToManager = false;
    private PlayerMovement playerMovement;
    private PlayerMovement playerMovement2;


    public float speed;


    
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerMovement2 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        target = GameObject.FindGameObjectWithTag("InteractTarget").GetComponent<InterTarget>();
        manager = GameObject.FindGameObjectWithTag("InteractManager").GetComponent<InteractManager>();
        anim = GetComponent<Animator>();
        playerMovement.enabled = false;
        playerMovement2.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {

        if (goingToManager == true)
        {

        }

        if (goingToManager == false)
        {
            if (target != null)
            {
                targetPosition = target.transform.position;
            }


        }
        if (Vector2.Distance(transform.position, targetPosition) > .1)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }


    void OnMouseOver()
    {


        anim.SetBool("isHovering", true);


    }

    void OnMouseExit()
    {
        anim.SetBool("isHovering", false);
    }

    void OnMouseDown()
    {
        anim.SetBool("click", true);

    }

    void OnMouseUp()
    {

        anim.SetBool("click", false);

    }

    public void BackToManager()
    {
        playerMovement.enabled = true;
        playerMovement2.enabled = true;
        goingToManager = true;
        StartCoroutine(waitAndDestroy());
        targetPosition = manager.transform.position;
    }

    IEnumerator waitAndDestroy()
    {
        
        yield return new WaitForSeconds(1);
        
        Destroy(gameObject);
        
    }


}
