using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerControllerScript))]
[RequireComponent (typeof (PlayerElementControllerScript))]
public class PlayerOverheatScript : MonoBehaviour {
	
	public float currentOverheat = 0f;
	public float overheatLimit = 100f;
	private float overheatIncreaseSpeed = 80f;
	private float overheatNormalDecreaseSpeed = 20f;
	private float overheatWaterDecreaseSpeed = 60f;

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
			IncreaseOverheat (Time.deltaTime);
		} else {
			DecreaseOverheat (Time.deltaTime);
		}

		if (currentOverheat >= overheatLimit) {
			playerControllerScript.Die ();
			currentOverheat = 0f;
		}
	}

	void IncreaseOverheat (float multiplier) {
		currentOverheat += overheatIncreaseSpeed * multiplier;
	}

	void DecreaseOverheat (float multiplier) {
		currentOverheat = Mathf.Clamp (currentOverheat - (OverheatDecreaseSpeed() * multiplier), 0, currentOverheat);
	}

	float OverheatDecreaseSpeed () {
		if (elementControllerScript.currentElement == PlayerElementControllerScript.Element.Water) {
			return overheatWaterDecreaseSpeed;
		}
		
		return overheatNormalDecreaseSpeed;
	}
}
