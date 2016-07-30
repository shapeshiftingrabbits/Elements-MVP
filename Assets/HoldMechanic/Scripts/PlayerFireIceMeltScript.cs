using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerElementControllerScript))]
[RequireComponent (typeof (CapsuleCollider))]
public class PlayerFireIceMeltScript : MonoBehaviour {

	private PlayerElementControllerScript elementControllerScript;
	private CapsuleCollider capsuleCollider;
	private LayerMask iceLayer;

	// Use this for initialization
	void Start () {
		elementControllerScript = GetComponent<PlayerElementControllerScript> ();
		iceLayer = LayerMask.NameToLayer ("Ice");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider other) {
		if (elementControllerScript.currentElement == PlayerElementControllerScript.Element.Fire) {
			if (other.gameObject.layer == iceLayer) {
				IceMeltScript iceMeltScript = other.gameObject.GetComponent<IceMeltScript> ();
				iceMeltScript.Melt (Time.deltaTime);
			}
		}
	}
}
