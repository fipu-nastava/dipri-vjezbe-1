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

		//Time.deltaTime - vrijeme koje je proteklo od prošlog framea, kako bi brzina rotacije bila 
		// nezavisna brzini izvođenja igre

		this.transform.Rotate(Vector3.up * brzinaRotacije * Time.deltaTime, Space.World);
	}
}
