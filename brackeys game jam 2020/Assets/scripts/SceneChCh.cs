using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChCh : MonoBehaviour
{
    private SceneChecker sceneChecker;


    // Start is called before the first frame update
    void Start()
    {
        sceneChecker = GameObject.FindGameObjectWithTag("SceneChecker").GetComponent<SceneChecker>();

        sceneChecker.CheckForObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
