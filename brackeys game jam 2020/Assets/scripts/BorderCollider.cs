using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public UnityEvent OnHit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit.Invoke();

    }
}
