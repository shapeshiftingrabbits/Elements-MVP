using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Renderer))]
[RequireComponent (typeof (Collider))]
[RequireComponent (typeof (PlayerControllerScript))]
public class PlayerElementControllerScript : MonoBehaviour {

	public enum Element
	{
		None,
		Water,
		Fire
	}

	private Dictionary<Element, Color> elementColors = new Dictionary<Element, Color>()
	{
		{Element.None, Color.grey},
		{Element.Water, Color.blue},
		{Element.Fire, Color.red}
	};

	public Element currentElement = Element.None;
	private Renderer playerRenderer;
	private Collider playerCollider;
	private PlayerControllerScript playerControllerScript;
	private LayerMask fireLayer;
	private LayerMask waterLayer;

	// Use this for initialization
	void Start () {
		playerRenderer = GetComponent<Renderer> ();
		playerCollider = GetComponent<Collider> ();
		playerControllerScript = GetComponent<PlayerControllerScript> ();
		fireLayer = LayerMask.NameToLayer ("Fire");
		waterLayer = LayerMask.NameToLayer ("Water");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire Element")) {
			currentElement = Element.Fire;
		} else if (Input.GetButton ("Water Element")) {
			currentElement = Element.Water;
		}
		else {
			currentElement = Element.None;
		}

		playerRenderer.material.color = elementColor();
	}

	void FixedUpdate () {
		if (currentElement == Element.Fire) {
			Physics.IgnoreLayerCollision (gameObject.layer, fireLayer, true);
		} else if (currentElement == Element.Water) {
			Physics.IgnoreLayerCollision (gameObject.layer, waterLayer, true);
		}
		else {
			Physics.IgnoreLayerCollision (gameObject.layer, fireLayer, false);
			Physics.IgnoreLayerCollision (gameObject.layer, waterLayer, false);
		}
	}

	Color elementColor () {
		if (elementColors.ContainsKey(currentElement))
			return elementColors[currentElement];
		else
			return elementColors[Element.None];
	}

	void OnCollisionEnter (Collision collision) {
		if ((collision.gameObject.layer == fireLayer || collision.gameObject.layer == waterLayer) && (playerCollider.bounds.Intersects(collision.collider.bounds))) {
			playerControllerScript.ResetPosition ();
		}
	}
}
