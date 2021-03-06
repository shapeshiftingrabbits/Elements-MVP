﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Transform))]
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Renderer))]
public class PlayerControllerScript : MonoBehaviour {

	public float movementSpeed = 5f;

	Transform playerTransform;
	Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();
		playerRigidbody = GetComponent<Rigidbody> ();
		ResetPosition ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float horizontalAxisOffset = Input.GetAxis ("Horizontal");
		float verticalAxisOffset = Input.GetAxis ("Vertical");

		Move (horizontalAxisOffset, verticalAxisOffset);
	}

	void Move(float horizontalAxisOffset, float verticalAxisOffset) {
		Vector3 movement = new Vector3 (horizontalAxisOffset * movementSpeed * Time.deltaTime,  0f, verticalAxisOffset * movementSpeed * Time.deltaTime);

		playerRigidbody.MovePosition (playerTransform.position + movement);
	}

	public void ResetPosition () {
		playerTransform.position = new Vector3 (-4f, 0.5f, 4f);
	}

	public void Die () {
		SceneManager.LoadScene ("MainScene");
	}
}