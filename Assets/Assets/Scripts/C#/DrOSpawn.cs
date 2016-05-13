using UnityEngine;
using System.Collections;

public class DrOSpawn : MonoBehaviour {

	public GameObject DrOPrefab;

	void Awake () {

	}

	void Start () {
		Instantiate (DrOPrefab);
	}
	
	void Update () {
	
	}
}
