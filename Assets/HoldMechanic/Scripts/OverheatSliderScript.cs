using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverheatSliderScript : MonoBehaviour {

	private GameObject player;
	private PlayerOverheatScript playerOverheatScript;
	private Slider overheatSlider;

	void Start () {
		player = GameObject.Find ("Player(Clone)");

		playerOverheatScript = player.GetComponent<PlayerOverheatScript> ();
		overheatSlider = gameObject.GetComponent<Slider> ();

		overheatSlider.maxValue = playerOverheatScript.overheatLimit;
		overheatSlider.value = playerOverheatScript.currentOverheat;
	}

	void Update () {
		overheatSlider.value = playerOverheatScript.currentOverheat;
		overheatSlider.transform.position = sliderPosition();
	}

	Vector3 sliderPosition () {
		return new Vector3 (player.transform.position.x, 2, player.transform.position.z + 0.7f);
	}
}
