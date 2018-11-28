using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineSpawner : MonoBehaviour {

	public int numTurbinesTarget = 0;	

	public float spawnArea = 200000.0f;

	private List<GameObject> turbineGOs = new List<GameObject>();
	public GameObject turbinePrefab;
	 

	// Use this for initialization
	void Start () {
		
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea, 100.0f, spawnArea));
	}
	
	// Update is called once per frame
	void Update () {
		if (numTurbinesTarget != turbineGOs.Count){
			while(turbineGOs.Count > numTurbinesTarget && numTurbinesTarget > 0){
				var t = turbineGOs[0];
				turbineGOs.RemoveAt(0);
				Destroy(t);
			}
			while(turbineGOs.Count < numTurbinesTarget && numTurbinesTarget > 0){
				var t = GameObject.Instantiate(turbinePrefab, Vector3.zero, Quaternion.identity);
				t.transform.parent = transform;
				t.transform.Rotate(0.0f, Random.Range(-180.0f, 180.0f), 0.0f, Space.Self);
				t.transform.localPosition = new Vector3(Random.Range(-spawnArea/2.0f, spawnArea/2.0f), 0.0f, Random.Range(-spawnArea/2.0f, spawnArea/2.0f));
				turbineGOs.Add(t);
			}

			if (numTurbinesTarget == 0){
				for (int i=0; i < turbineGOs.Count; i++){
					var t = turbineGOs[i];
					turbineGOs.RemoveAt(0);
					DestroyImmediate(t);
				}
			}
		}
	}
}
