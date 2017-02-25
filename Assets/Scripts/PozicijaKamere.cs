using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PozicijaKamere : MonoBehaviour {

	// referenca da objekt koji kontroliramo
	public GameObject player;

	private Vector3 pocetnaUdaljenost;

	// Use this for initialization
	void Start () {
		pocetnaUdaljenost = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// LateUpdate se poziva pri završetku iscrtavanja
	void LateUpdate() {
		this.transform.position = player.transform.position + pocetnaUdaljenost;
	}
}
