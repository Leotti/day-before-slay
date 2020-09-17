using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChecker : MonoBehaviour
{
    private GameObject sceneCheckerObject;
    private PlayerMovement streetPLayerScript;


    public GameObject houseGreenKey;
    [HideInInspector]
    public GameObject houseBrownKey;
    [HideInInspector]
    public GameObject houseGreyKey;

    [HideInInspector]
    public bool greenIsDropped;
    [HideInInspector]
    public bool greyIsDropped;
    [HideInInspector]
    public bool brownIsDropped;
    [HideInInspector]
    public bool crowIsDropped;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        houseGreenKey = GameObject.FindGameObjectWithTag("GreenHouseKey");
        houseBrownKey = GameObject.FindGameObjectWithTag("BrownHouseKey");
        houseGreyKey = GameObject.FindGameObjectWithTag("GreyHouseKey");

        streetPLayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    void Update()
    {
        sceneCheckerObject = GameObject.FindGameObjectWithTag("SceneObject");

        if (sceneCheckerObject != null)
        {
            if (houseGreenKey != null)
            {
                houseGreenKey.SetActive(false);
            }

            //houseBrownKey.SetActive(false);

            //houseGreyKey.SetActive(false);
        }
        else
        {
            if(streetPLayerScript.hasGreenKey == true || greenIsDropped == true)
            {
                if(houseGreenKey != null)
                houseGreenKey.SetActive(true);
            }
            
            //houseBrownKey.SetActive(true);
            //houseGreyKey.SetActive(true);
        }
    }

    public void CheckForObject()
    {

    }
}
