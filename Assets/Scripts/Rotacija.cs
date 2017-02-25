using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacija : MonoBehaviour {

	public float brzinaRotacije;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.up * brzinaRotacije, Space.World);
	}
}
