using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
	[Header("RotationController")]
	// the speed of the rotation
	public float speed = 100.0f;

	// setup the possible rotation states
	public enum whichWayToRotate { AroundX, AroundY, AroundZ }

	// set the direction of the rotation
	public whichWayToRotate way = whichWayToRotate.AroundX;
	public bool antiClockwise;
	private int rotateTowards = 1;

	private void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (antiClockwise)
			rotateTowards = -1;
		else
			rotateTowards = 1;
			switch (way)
		{
			case whichWayToRotate.AroundX:
				transform.Rotate(Vector3.right * Time.deltaTime * speed*rotateTowards);
				break;
			case whichWayToRotate.AroundY:
				transform.Rotate(Vector3.up * Time.deltaTime * speed*rotateTowards);
				break;
			case whichWayToRotate.AroundZ:
				transform.Rotate(Vector3.forward * Time.deltaTime * speed*rotateTowards);
				break;
		}
	}
}
