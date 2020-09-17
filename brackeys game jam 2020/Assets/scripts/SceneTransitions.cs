using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    private Animator transitionAnim;
    private PlayerMovement player;
    
    public GameObject playerObject;



    // Start is called before the first frame update
    void Start()
    {
        
        transitionAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {

  
        StartCoroutine(Transition(sceneName));
        
    }

    IEnumerator Transition(string sceneName)
    {

        transitionAnim.SetTrigger("end");
        if (sceneName != "street")
        {

        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);


    }



}
