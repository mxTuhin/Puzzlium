using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTeethEnemy : MonoBehaviour
{

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
       print("Trigger");
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            _animator.SetTrigger("hasCatched");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            
                
        }
    }
}
