using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWASDController : MonoBehaviour {

	public float speed = 0.1f;
	public float wobbleAmplitude = 0.1f;
	public float wobbleSpeed = 0.1f;
	private float wobbleOffset = 0;

	static int NUM_WOBBLE_COMPONENTS = 16;

	private Vector3 pos;
	private Vector3 wobble;

	private List<Vector3> wobbleComponents;

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		pos = transform.position;

		wobbleComponents = new List<Vector3>();

		for (int i=0; i < NUM_WOBBLE_COMPONENTS; i++){
			wobbleComponents.Add(Random.onUnitSphere);
		}
	}
	
	// Update is called once per frame
	void Update () {

		

		if (Input.GetKey(KeyCode.W)){
			pos += Vector3.forward * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.A)){
			pos += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.D)){
			pos += Vector3.right * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.S)){
			pos += Vector3.back * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.LeftControl)){
			pos += Vector3.down * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.LeftShift)){
			pos += Vector3.up * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.Q)){
			transform.RotateAroundLocal(Vector3.up, speed * 0.01f * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.E)){
			transform.RotateAroundLocal(Vector3.up, speed * -0.01f * Time.deltaTime);
		}

		wobbleOffset += Time.deltaTime * wobbleSpeed;
		wobble = Vector3.zero;
		for (int i=0; i < NUM_WOBBLE_COMPONENTS; i++){
			wobble += wobbleComponents[i] * wobbleAmplitude * Mathf.Sin((i * (360/(float)NUM_WOBBLE_COMPONENTS) * wobbleOffset));
		}

		transform.position = pos + wobble;
		
	}
}
