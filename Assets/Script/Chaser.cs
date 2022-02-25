using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float speed = 20.0f;
    public float minDist = 1f;
    private Vector3 target;
    public Vector3 chasingPoint;

    public bool hasDelayTime;
    public float delayTimer;
    private float currentTime;
    
    public enum ChaseTowards
    {
        up, forward
    }

    public ChaseTowards chaseTowards;

    // Use this for initialization
    void Start ()
    {
        target = transform.position + chasingPoint;
        if (hasDelayTime)
            currentTime = Time.time;
        // speed = Random.Range(20, 40);
    }
	
    // Update is called once per frame
    void Update () 
    {
        if (hasDelayTime)
        {
            if(Time.time-currentTime>delayTimer)
                chasePoint();
        }
        else
        {
            chasePoint();
        }
    }

    void chasePoint()
    {
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position,target);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
        {
            switch (chaseTowards)
            {
                case ChaseTowards.up:
                    transform.position += transform.up * speed * Time.deltaTime;
                    break;
                case ChaseTowards.forward:
                    transform.position += transform.forward * speed * Time.deltaTime;
                    break;
            }
            // print(distance);
        }
    }

    
}
