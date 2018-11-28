using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public DroneWASDController drone;
	public BladesRotator blades;
	public TurbineSpawner turbineSpawner;

	public Light sunlight;
	private float sunAzimuth = 0;
	private float sunElevation = 0;

	public bool showGUI = true;

	private int offset = 0;

	// Use this for initialization
	void Start () {
		sunAzimuth = sunlight.transform.rotation.eulerAngles.y;
		sunElevation = sunlight.transform.rotation.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G)){
			showGUI = !showGUI;
		}
	}

	void OnGUI(){
		if (!showGUI) return;
		offset = 0;

		drone.speed = FloatSlider(drone.speed, 1f, 500.0f, "Drone Move Speed : " + drone.speed);
		drone.wobbleAmplitude = FloatSlider(drone.wobbleAmplitude, 0.00f, 2.0f, "Drone Wobble Amplitude : " + drone.wobbleAmplitude);
		drone.wobbleSpeed = FloatSlider(drone.wobbleSpeed, 0.001f, 0.1f, "Drone Wobble Speed : " + drone.wobbleSpeed);
		blades.RPM = FloatSlider(blades.RPM, 0.1f, 50.0f, "Blades RPM : " + blades.RPM);
		Camera.main.fieldOfView = FloatSlider(Camera.main.fieldOfView, 10.0f, 180.0f, "CameraFOV : " + Camera.main.fieldOfView);

		sunAzimuth = FloatSlider(sunAzimuth, 0f, 180.0f, "Sun Azimuth : " + sunAzimuth);
		sunElevation = FloatSlider(sunElevation, 0f, 180.0f, "Sun Elevation : " + sunElevation);

		sunlight.transform.rotation = Quaternion.Euler(sunElevation, sunAzimuth, 0.0f);

		sunlight.intensity = FloatSlider(sunlight.intensity, 0f, 2.0f, "Sun Intensity : " + sunlight.intensity);
		turbineSpawner.numTurbinesTarget = (int)FloatSlider(turbineSpawner.numTurbinesTarget, 0f, 40.0f, "Num Turbines : " + (int)turbineSpawner.numTurbinesTarget);
	}


	float FloatSlider(float val, float min, float max, string label){
		GUI.Label(new Rect(25, 25 + offset, 200, 30), label);
		offset += 25;
		return GUI.HorizontalSlider(new Rect(25, (offset += 25), 100, 30), val, min, max);
	}


}
