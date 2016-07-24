using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerControllerScript))]
[RequireComponent (typeof (PlayerElementControllerScript))]
public class PlayerOverheatScript : MonoBehaviour {
	
	public float currentOverheat = 0f;
	private float overheatLimit = 100f;
	private float overheatIncreaseSpeed = 50f;
	private float overheatDecreaseSpeed = 50f;

	private PlayerControllerScript playerControllerScript;
	private PlayerElementControllerScript elementControllerScript;

	// Use this for initialization
	void Start () {
		playerControllerScript = GetComponent<PlayerControllerScript> ();
		elementControllerScript = GetComponent<PlayerElementControllerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (elementControllerScript.currentElement == PlayerElementControllerScript.Element.Fire) {
			IncreaseOverheat ();
		} else if (elementControllerScript.currentElement == PlayerElementControllerScript.Element.Water) {
			currentOverheat = 0f;
		}
		else {
			DecreaseOverheat ();
		}

		if (currentOverheat >= overheatLimit) {
			playerControllerScript.ResetPosition ();
			currentOverheat = 0f;
		}
	}

	void IncreaseOverheat () {
		currentOverheat += overheatIncreaseSpeed * Time.deltaTime;
	}

	void DecreaseOverheat () {
		if (currentOverheat >= 0f) {
			currentOverheat -= overheatDecreaseSpeed * Time.deltaTime;
		}

		if (currentOverheat < 0f) {
			currentOverheat = 0f;
		}
	}
}
