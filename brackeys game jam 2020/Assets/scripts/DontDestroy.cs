using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;
    private GameObject[] others;

    private void Start()
    {
        others = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (others.Length != 1)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

            
        }
    }
}
