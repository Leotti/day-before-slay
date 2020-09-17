using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    private GameObject player;

    private Vector2 targetPosition;

    public float speed;

    private key keyScript;





    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        keyScript = GameObject.FindGameObjectWithTag("key").GetComponent<key>();

        UnityEngine.Debug.Log("oon tyhm");
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, animator.transform.position.z);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UnityEngine.Debug.Log("oon lol");
    }


}
