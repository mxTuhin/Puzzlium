using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class AbstractAnimationController : MovingPlatformerGameobject
{
    [Header("Abstract Animation Controller")]
    [SerializeField] private bool shouldAnim;
    private Animator _animator;
    

    
    private enum AnimatorDecider
    {
        flat_rotate,
        right_left,
        cylinder_rotate,
        get_smaller
    }

    [SerializeField] private AnimatorDecider _animatorDecider;
    // Start is called before the first frame update
    void Start()
    {
        primaryPos = transform.position;
        if(!shouldAnim)
            return;
        _animator = GetComponent<Animator>();
        switch (_animatorDecider)
        {
            case AnimatorDecider.flat_rotate:
                _animator.SetTrigger("Flat_Rotate");
                break;
            case AnimatorDecider.cylinder_rotate:
                _animator.SetTrigger("Cylinder_Rotate");
                break;
            
        }

        

    }
    

    // Update is called once per frame
    void Update()
    {
        if(dontWorkTwice)
            return;
        switch (_animatorDecider)
        {
            
            case AnimatorDecider.right_left:
                if(shouldAnim)
                    waypointChaser();
                break;
            case AnimatorDecider.get_smaller:
                if(shouldAnim)
                    getSmaller(); 
                break;
                
        }
        
    }
    #region waypointChaser

    [Header("waypointChaser")] public Vector3[] target;

    private int pointIndex = 0;
    private float minDist = 0.5f;
    [SerializeField]private bool shouldStop = false;
    private Vector3 primaryPos;

    void waypointChaser()
    {
        // print(primaryPos);
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position,primaryPos+target[pointIndex]);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
        {
            if(!requireTrigger)
                transform.position = Vector3.MoveTowards(transform.position, primaryPos+target[pointIndex], speed*Time.deltaTime);
        }
        else
        {
            if (shouldStop)
            {
                if (pointIndex < target.Length - 1)
                {
                    pointIndex += 1;
                }

                dontWorkTwice = true;
            }
                
            else
            {
                pointIndex = (pointIndex+ 1) % target.Length;
            }
                
        }
    }
    #endregion
    
    #region getSmaller

    private void getSmaller()
    {
        if(!requireTrigger)
            _animator.SetTrigger("get_smaller");
    }
    
    #endregion
    
}
