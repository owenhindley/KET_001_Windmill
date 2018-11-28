using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesRotator : MonoBehaviour {

	public float RPM = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float revsPerSecond = RPM / 60.0f;
		float revsThisFrame = revsPerSecond * Time.deltaTime;
		float degreesThisFrame =  360.0f * revsThisFrame;
		transform.RotateAround(transform.position, transform.forward, degreesThisFrame);
	}
}
