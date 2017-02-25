using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Kontrola : MonoBehaviour {

	public float snagaSileKretanja;

	// reference na Text elemente (UI)
	public Text bodoviText;
	public Text pobjedaText;
	public Text vrijemeText;
	public GameObject winObjects;

	// referenca na komponentu
	private Rigidbody rb;

	// vrijeme početka igre
	private DateTime startTime;

	private int sakupljeniBodovi = 0;

	private bool gameStarted = false;

	private bool pobjeda = false;

	// Inicijalizacija
	void Start () {

		// pristup komponenti koju smo dodali u Unity-u objektu
		rb = GetComponent<Rigidbody>();
		updateBodovi();
	}
	
	// Zove se jednom kod svakog iscrtavanja sadržaje (engl. Frame)
	void Update ()
	{
		if (!pobjeda) {
			TimeSpan span = TimeSpan.FromMilliseconds(0);
			if (gameStarted) {
				span = (DateTime.Now - startTime);
			}

			String razlika = String.Format ("{0:00}:{1:00}:{2:00}.{3:000}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds);

			// osvježi vrijeme
			vrijemeText.text = "Vrijeme: " + razlika;
		}
	}

	// Alternativa "Update"-u, koristi se za izračun fizičkih svojstava
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// nešto je stisnuto, postoji smjer, pokreni igru!
		if (!gameStarted && movement.magnitude > 0) {
			pokreniBrojac ();
		}

		rb.AddForce(movement * snagaSileKretanja);
	}

	void OnTriggerEnter (Collider drugiObjekt)
	{

		// zgodno za debug
		Debug.Log ("Collision with " + drugiObjekt.ToString ());

		if (drugiObjekt.CompareTag ("PickUp")) {
			sakupljeniBodovi++;

			updateBodovi();

			drugiObjekt.gameObject.SetActive(false);
		}
	}

	void pokreniBrojac ()
	{
		gameStarted = true;
		// zabilježi vrijeme početka
		startTime = DateTime.Now;
	}

	void updateBodovi ()
	{
		bodoviText.text = "Bodovi: " + sakupljeniBodovi;
		if (sakupljeniBodovi >= 12) {
			pobjeda = true;
			pobjedaText.text = "Pobjeda!";
			winObjects.SetActive(true);
		} else {
			pobjedaText.text = "";
		}
	}

	public void restartClick ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 	}
 	public void exitClick ()
	{
		Application.Quit();
	}
}
