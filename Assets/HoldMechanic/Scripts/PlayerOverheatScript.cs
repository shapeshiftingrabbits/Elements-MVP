using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerElementControllerScript))]
public class PlayerOverheatScript : MonoBehaviour {

	public PlayerElementControllerScript elementControllerScript;

	public float currentOverheat = 0f;
	private float overheatLimit = 100f;
	private float overheatIncreaseSpeed = 50f;
	private float overheatDecreaseSpeed = 50f;

	// Use this for initialization
	void Start () {
	
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
			ResetPlayerPosition ();
			currentOverheat = 0f;
		}
	}

	void ResetPlayerPosition () {
		transform.position = new Vector3 (-4f, 0.5f, 4f);
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
