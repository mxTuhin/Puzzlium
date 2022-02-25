using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Animator _animator;
    private CinemachineDollyCart cmDolly;
    private bool playerHit;
    private GameObject playerObject;
    public float minimumDistance ;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        cmDolly = GetComponent<CinemachineDollyCart>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        Destroy(cmDolly);
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            transform.LookAt(hit.transform);
            playerHit = true;
            playerObject = hit;

        }
        
    }

    private void Update()
    {
        if(playerHit){
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
            if (distance > minimumDistance)
            {
                transform.position += transform.forward * (10 * Time.deltaTime);
                print(distance);
            }
            
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
