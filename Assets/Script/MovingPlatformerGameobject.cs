using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformerGameobject : MonoBehaviour
{
    [Header("Collision Controller")]
    [SerializeField]private bool shouldSetParent;

    public bool requireTrigger;
    [SerializeField]protected float speed;
    [SerializeField]protected bool dontWorkTwice;

    private void OnTriggerEnter(Collider collision)
    {
        if(dontWorkTwice)
            return;
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            if (shouldSetParent)
            {
                hit.transform.parent = transform;
            }
            requireTrigger = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(dontWorkTwice)
            return;
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            if (shouldSetParent)
            {
                hit.gameObject.transform.parent = null;
            }
                
        }
    }

}
