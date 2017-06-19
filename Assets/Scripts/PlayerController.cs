using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private int PickUpCounter;
	public Text CounterText;
	public Text WinText;
	public int speed;
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		PickUpCounter = 0;
		SetCounterText ();
		WinText.text = "";
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			PickUpCounter++;
			SetCounterText ();
		}
	}
	void SetCounterText()
	{
		CounterText.text = "Count: " + PickUpCounter.ToString ();
		if (PickUpCounter == 10)
			WinText.text = "You Win!";
	}

}
