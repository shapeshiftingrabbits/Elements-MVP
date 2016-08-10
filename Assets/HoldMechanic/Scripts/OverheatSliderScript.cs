using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverheatSliderScript : MonoBehaviour {

	private PlayerOverheatScript playerOverheatScript;
	private Slider overheatSlider;

	void Start () {
		GameObject player = GameObject.Find ("Player(Clone)");

		playerOverheatScript = player.GetComponent<PlayerOverheatScript> ();
		overheatSlider = gameObject.GetComponent<Slider> ();

		overheatSlider.maxValue = playerOverheatScript.overheatLimit;
		overheatSlider.value = playerOverheatScript.currentOverheat;
	}

	void Update () {
		overheatSlider.value = playerOverheatScript.currentOverheat;
	}
}
