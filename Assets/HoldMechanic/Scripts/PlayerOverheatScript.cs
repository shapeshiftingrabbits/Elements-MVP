using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerControllerScript))]
[RequireComponent (typeof (PlayerElementControllerScript))]
public class PlayerOverheatScript : MonoBehaviour {
	
	public float currentOverheat = 0f;
	public float overheatLimit = 100f;
	private float overheatIncreaseSpeed = 80f;
	private float overheatDecreaseSpeed = 20f;

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
		} else if (elementControllerScript.currentElement == PlayerElementControllerScript.Element.Water) {
			DecreaseOverheat (Time.deltaTime * 3);
		}
		else {
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
		currentOverheat = Mathf.Clamp (currentOverheat - (overheatDecreaseSpeed * multiplier), 0, currentOverheat);
	}
}
