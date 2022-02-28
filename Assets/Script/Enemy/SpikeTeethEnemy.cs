using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        if (hit.CompareTag("Pushable"))
        {
            StartCoroutine(triggerTimelyAnimation(0.5f, hit));


        }
    }

    IEnumerator triggerTimelyAnimation(float timer, GameObject hit)
    {
        _animator.SetTrigger("hasCatched");
        yield return new WaitForSeconds(timer);
        Destroy(hit);
        Destroy(gameObject);
        
    }
    private void OnTriggerExit(Collider collision)
    {
        
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            
                
        }
    }
}
