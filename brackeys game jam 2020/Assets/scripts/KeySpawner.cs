using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    private SceneChecker sceneCheckerScript;

    //greens
    private int numberOfGreenKeys;
    private GameObject[] greenKeys;
    private GameObject greenHouseKeyInScene;
    public GameObject greenHouseKey;

    //greys

    private int numberOfGreyKeys;
    private GameObject[] greyKeys;
    private GameObject greyHouseKeyInScene;
    public GameObject greyHouseKey;


    void Awake()
    {
        sceneCheckerScript = GameObject.FindGameObjectWithTag("SceneChecker").GetComponent<SceneChecker>();

        DontDestroyOnLoad(this.gameObject);

        //greens spawn

        greenHouseKeyInScene = sceneCheckerScript.houseGreenKey;
        greenKeys = GameObject.FindGameObjectsWithTag("GreenHouseKey");

        numberOfGreenKeys = greenKeys.Length;

        if (numberOfGreenKeys == 0)
        {
            UnityEngine.Debug.Log("spawnGreen");
            Instantiate(greenHouseKey, transform.position, transform.rotation);
        }

        //greys spawn

        greyHouseKeyInScene = sceneCheckerScript.houseGreyKey;
        greyKeys = GameObject.FindGameObjectsWithTag("GreyHouseKey");

        numberOfGreyKeys = greyKeys.Length;

        if (numberOfGreyKeys == 0)
        {
            UnityEngine.Debug.Log("spawnGrey");
            Instantiate(greyHouseKey, transform.position, transform.rotation);
        }
    }

    void Update()
    {
        greenHouseKeyInScene = sceneCheckerScript.houseGreenKey;
        greenKeys = GameObject.FindGameObjectsWithTag("GreenHouseKey");
        
    }


    void Start()
    {
        

    }

}
